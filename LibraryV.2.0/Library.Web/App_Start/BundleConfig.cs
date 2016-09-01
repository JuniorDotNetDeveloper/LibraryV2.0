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

            Bundle scriptsJqueryUi = new Bundle("~/bundles/jqueryUi");
            scriptsJqueryUi.Include("~/scripts/jquery-ui-{version}.js");
            bundles.Add(scriptsJqueryUi);

            Bundle stylesBundle = new Bundle("~/Content/css");
            stylesBundle.Include("~/Content/bootstrap.min.css");
            stylesBundle.Include("~/Content/shop-homepage.css");
            stylesBundle.Include("~/Content/Site.css");
            bundles.Add(stylesBundle);

            Bundle stylesJqueryUI = new Bundle("~/Content/themes/base/jquery-ui-styles");
            stylesJqueryUI.Include("~/Content/themes/base/jquery-ui.min.css");
            //stylesJqueryUI.Include("~/Content/themes/base/jquery-ui.structure.css");
            stylesJqueryUI.Include("~/Content/themes/base/jquery-ui.theme.css");
            bundles.Add(stylesJqueryUI);


            Bundle onCreateBook = new Bundle("~/scripts/Custom/OnCreate");
            onCreateBook.Include("~/scripts/Custom/OnCreateBook.js");
            bundles.Add(onCreateBook);

            Bundle onCategoryMenu = new Bundle("~/scripts/Custom/OnCategoryMenu");
            onCategoryMenu.Include("~/scripts/Custom/OnCategoryMenu.js");
            bundles.Add(onCategoryMenu);
            

            BundleTable.EnableOptimizations = true;
        }
    }
}