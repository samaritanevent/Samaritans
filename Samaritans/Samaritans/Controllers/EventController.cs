using Microsoft.AspNet.Identity;
using Samaritans.Data.Entities;
using Samaritans.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Samaritans.Controllers
{
    public class EventController : Controller
    {
        private DoGooderDb db;

        public EventController()
        {
            db = new DoGooderDb();
        }

        public ActionResult Index()
        {
            var numberGen = new Random();

            var results = db.Events
                .AsEnumerable()
                .Select(x => new EventListModel
                {
                    Name = x.Name,
                    EventDate = x.EventDate,
                    MaxAttendance = x.MaxAttendance,
                    MinAttendance = x.MinAttendance,
                    Purpose = x.Purpose,
                    OrganizerName = User.Identity.GetUserName(),
                    DistanceFromUser = decimal.Parse($"{numberGen.Next(1, 10)}.{numberGen.Next(1, 10)}")
                }).ToList();

            return View(results);
        }

        public ActionResult Details(int id)
        {
            var e = db.Events.Find(id);
            var userId = User.Identity.GetUserId();
            var currentUser = db.AspNetUsers.Find(userId);
            return View(new EventViewModel(e, currentUser));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventCreateModel eventModel)
        {
            // ToDo: Replace with custom Create view model.
            var eventEntity = new Event
            {
                Name = eventModel.Name,
                EventDate = eventModel.EventDate,
                MaxAttendance = eventModel.MaxAttendance,
                MinAttendance = eventModel.MinAttendance,
                Purpose = eventModel.Purpose,
                OrganizerId = User.Identity.GetUserId()
            };

            db.Events.Add(eventEntity);
            db.SaveChanges();

            return View("Index");
        }
        public JsonResult GetEvents(DateTime startDate, DateTime endDate)
        {
            var results = new List<FullCalendarEventModel>();

            foreach (var eventRecord in db.Events.Where(x => x.EventDate >= startDate && x.EventDate <= endDate))
            {
                //TimeSpan variable = datevalue1 - datevalue2;
                results.Add(new FullCalendarEventModel()
                {
                    id = eventRecord.Id.ToString(),
                    title = "An Event!",
                    start = eventRecord.EventDate,
                    end = eventRecord.EventDate.AddDays(1),
                    backgroundColor = "#C2C2C2",
                    url = Url.Action("Details", "Event", new { id = eventRecord.Id }),
                    className = eventRecord.MinAttendance != eventRecord.MaxAttendance
                        ? ""
                        : "EventFull"
                });
            }


            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}