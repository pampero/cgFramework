using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace Framework
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery-ui-{version}.js",
                     "~/Scripts/knockout-2.2.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvals").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/plugins/i18n/jquery.ui.datepicker-es.js",
                    "~/Scripts/plugins/jquery.jgrowl.js",
                    "~/Scripts/bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Bundle para la pantalla de login.
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/css/jquery.datepicker.css",
                "~/css/jquery.jgrowl.css",
                "~/css/bootstrap-responsive.css",
                "~/css/bootstrap.css"));

            // INFO: Si se ejecuta en modo release o BundleTable.EnableOptimizations es igual a 'true' se minifican todos los arhcivos. 
            BundleTable.EnableOptimizations = true;
        }
    }
}