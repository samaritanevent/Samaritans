using Microsoft.AspNet.Identity;
using Samaritans.Data.Entities;
using Samaritans.Models.Event;
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
            var results = db.Events.AsEnumerable()
                .Select(x => new EventViewModel(x, x.Organizer)).ToList();
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
            return View();
        }
    }
}