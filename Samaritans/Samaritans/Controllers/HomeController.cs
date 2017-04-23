using Samaritans.Models;
using System.Web.Mvc;

namespace Samaritans.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.FailedLogin = TempData["FailedLogin"];

            if (!User.Identity.IsAuthenticated)
            {
                var model = new ExternalLoginListViewModel()
                {
                    ReturnUrl = null
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Explore", "Event");
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