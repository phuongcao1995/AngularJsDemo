using System.Web;
using System.Web.Optimization;

namespace CasePortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/controllers/HomeController.js",
                        "~/Scripts/controllers/LogDetailcontroller.js",
                        "~/Scripts/commonService.js",
                        "~/Scripts/services/HomeService.js",
                        "~/Scripts/services/IncidentTypeService.js",
                        "~/Scripts/services/DistrictService.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/angularjs").Include(
                      "~/Areas/Admin/Scripts/controllers/HomeController.js",
                      "~/Areas/Admin/Scripts/controllers/LogDetailcontroller.js",
                      "~/Areas/Admin/Scripts/commonService.js",
                      "~/Areas/Admin/Scripts/services/HomeService.js",
                      "~/Areas/Admin/Scripts/services/IncidentTypeService.js",
                      "~/Areas/Admin/Scripts/services/DistrictService.js"));

            bundles.Add(new ScriptBundle("~/bundles/style").Include(
               "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminStyle").Include(
               "~/Content/adminStyle.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}
