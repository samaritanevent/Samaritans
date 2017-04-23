using Microsoft.AspNet.Identity;
using Samaritans.Data.Entities;
using Samaritans.Models.Event;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                .Where(e => e.IsAttending(CurrentUser))
                .Select(x => new EventListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    EventDate = x.EventDate,
                    MaxAttendance = x.MaxAttendance,
                    MinAttendance = x.MinAttendance,
                    Purpose = x.Purpose,
                    OrganizerName = x.Organizer?.UserName ?? "N/A",
                    IsOrganizing = x.Organizer == CurrentUser,
                    DistanceFromUser = decimal.Parse($"{numberGen.Next(1, 10)}.{numberGen.Next(1, 10)}")
                }).ToList();

            return View(results);
        }

        public ActionResult Details(int id)
        {
            var e = db.Events.Find(id);
            return View(new EventViewModel(e, CurrentUser));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventCreateModel eventModel)
        {
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

        [HttpGet]
        public ActionResult Explore()
        {
            return View();
        }

        public PartialViewResult ShowMore(string currentOffset)
        {
            var numberGen = new Random();

            DateTime convertedOffset;

            if (!DateTime.TryParse(currentOffset, out convertedOffset))
            {
                convertedOffset = DateTime.Today;
            }

            convertedOffset = convertedOffset.AddDays(7);

            var results = db.Events.Where(x => x.EventDate <= convertedOffset)
                .Include("Organizer")
                .AsEnumerable()
                .Select(x => new EventListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    EventDate = x.EventDate,
                    MaxAttendance = x.MaxAttendance,
                    MinAttendance = x.MinAttendance,
                    Purpose = x.Purpose,
                    OrganizerName = x.Organizer?.UserName ?? "N/A",
                    DistanceFromUser = decimal.Parse($"{numberGen.Next(x.Id, x.Id + 10)}.{numberGen.Next(x.Id, x.Id + 10)}")
                }).ToList();

            var vm = new EventExploreModel
            {
                Events = results,
                CurrentOffset = convertedOffset
            };

            return PartialView("_EventList", vm);
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

        [HttpPost]
        public ActionResult Cancel(int id)
        {
            var e = db.Events.Find(id);
            db.Events.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Join(int id)
        {
            var e = db.Events.Find(id);
            var newParticipant = new Attendee
            {
                Event = e,
                User = CurrentUser,
            };
            e.Participants.Add(newParticipant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private AspNetUser CurrentUser
        {
            get
            {
                var userId = User.Identity.GetUserId();
                return db.AspNetUsers.Find(userId);
            }
        }
    }
}