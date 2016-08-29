using System.Web.Optimization;

namespace Library.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            Bundle scriptBundle = new Bundle("~/bundles/jquery");
            scriptBundle.Include("~/scripts/jquery-{version}.js");
            scriptBundle.Include("~/scripts/jquery.validate*");
            scriptBundle.Include("~/scripts/modernizr-*");
            scriptBundle.Include("~/scripts/bootstrap.js", "~/scripts/respond.js");
            scriptBundle.Include("~/scripts/jquery-ui-{version}.js");

            bundles.Add(scriptBundle);

            Bundle stylesBundle = new Bundle("~/Content/css");
            stylesBundle.Include("~/Content/bootstrap.min.css");
            stylesBundle.Include("~/Content/themes/base/jquery-ui.min.css");
            stylesBundle.Include("~/Content/themes/base/jquery-ui.structure.css");
            stylesBundle.Include("~/Content/themes/base/jquery-ui.theme.css");
            stylesBundle.Include("~/Content/Site.css");

            bundles.Add(stylesBundle);
            BundleTable.EnableOptimizations = true;
        }
    }
}