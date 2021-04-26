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

                    bundles.Add(new StyleBundle("~/Contennt/admin-layout-style").Include(
                "~/Content/admin/assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/admin/assets/vendor/fonts/circular-std/style.css",
                "~/Content/admin/assets/libs/css/style.css",
                "~/Content/admin/assets/vendor/fonts/fontawesome/css/fontawesome-all.css"

             ));
            bundles.Add(new ScriptBundle("~/Content/admin-layout-scripts").Include(
                    "~/Content/admin/assets/vendor/jquery/jquery-3.3.1.min.js",
                    "~/Content/admin/assets/vendor/bootstrap/js/bootstrap.bundle.js",
                    "~/Content/admin/assets/vendor/slimscroll/jquery.slimscroll.js",
                    "~/Content/admin/assets/libs/js/main-js.js"
                ));
        }
    }
}
