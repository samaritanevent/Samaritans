using System.Web.Optimization;

namespace Samaritans
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/fullcalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/events").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/fullcalendar.js",
                        "~/Scripts/EventCalendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/explore").Include(
                        "~/Scripts/explore.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fullcalendar.css"));
        }
    }
}
