﻿namespace PhotoArtSystem.Web.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

            bundles.IgnoreList.Clear();

            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlCarousel").Include(
                      "~/Scripts/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymceJs").Include(
                     "~/Scripts/tinymce/tinymce.min.js",
                     "~/Scripts/Site/tinymce-init.js"));

            bundles.Add(new ScriptBundle("~/bundles/vegas").Include(
                      "~/Scripts/Vegas/vegas.js"));

            bundles.Add(new ScriptBundle("~/bundles/siteJs").Include(
                      "~/Scripts/Site/app.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/siteCss")
                .Include("~/Content/Site/site.css"));

            bundles.Add(new StyleBundle("~/Content/toolsCss")
                .Include(
                "~/Content/bootstrap.css",
                "~/Content/owl.carousel.css",
                "~/Content/Vegas/vegas.css"));
        }
    }
}
