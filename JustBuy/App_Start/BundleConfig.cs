using System.Web;
using System.Web.Optimization;

namespace JustBuy
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/layouts-styles").Include(
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/lib/css/nivo-slider.css",
                    "~/Content/css/core.css",
                    "~/Content/css/shortcode/shortcodes.css",
                    "~/Content/css/style.css",
                    "~/Content/css/responsive.css",
                    "~/Content/css/color/color-core.css",
                    "~/Content/css/custom.css"
                   ));

            bundles.Add(new ScriptBundle("~/Content/layouts-scripts").Include(
                    "~/Content/js/vendor/jquery-3.1.1.min.js",
                    "~/Content/js/bootstrap.min.js",
                    "~/Content/lib/js/jquery.nivo.slider.js",
                    "~/Content/js/plugins.js",
                    "~/Content/js/main.js"
                ));
        }
    }
}
