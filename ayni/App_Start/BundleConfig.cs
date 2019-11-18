using System.Web;
using System.Web.Optimization;

namespace ayni
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

            bundles.Add(new ScriptBundle("~/bundles/eventos").Include(
                        "~/Scripts/eventos/evento-*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/Zero-css/jquery.dataTables.min.css",
                      "~/Content/css/estilos.css"
                      /*,
                      "~/Content/site.css"*/));

            bundles.Add(new ScriptBundle("~/bundles/Zero/jquery").Include(
                        "~/Scripts/Zero-js/jquery.dataTables.min.js",
                        "~/Scripts/Zero-js/Javascript.js"));
        }
    }
}
