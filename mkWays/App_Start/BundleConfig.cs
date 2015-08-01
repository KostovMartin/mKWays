using System.Web.Optimization;

namespace MkWays
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/custom.js",
                "~/Scripts/MkAjax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/googleMaps").Include(
                "~/Scripts/jquery.gmap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/icons.css",
                "~/Content/icons-color.css",
                "~/Content/social-icons.css",
                "~/Content/style.css"));
        }
    }
}