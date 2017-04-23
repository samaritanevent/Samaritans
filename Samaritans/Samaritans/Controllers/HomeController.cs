using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samaritans.Models;

namespace Samaritans.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (!User.Identity.IsAuthenticated)
            {
                var model = new ExternalLoginListViewModel()
                {
                    ReturnUrl = null
                };

                return View(model);
            }
            //else
            {
                return RedirectToAction("Index", "Event");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}