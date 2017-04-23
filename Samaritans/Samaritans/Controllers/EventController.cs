using Microsoft.AspNet.Identity;
using Samaritans.Data.Entities;
using Samaritans.Models;
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
            return View();
        }

        public ActionResult Details(int index)
        {
            var e = db.Events.Find(index);
            return View(new EventViewModel(e));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventViewModel eventModel)
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
            return View();
        }
    }
}