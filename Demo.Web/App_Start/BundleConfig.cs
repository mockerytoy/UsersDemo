using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Demo.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true; // I'm not using CDN right now but put it here just in case to remember this option exist.

            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker-css").Include(
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"));

            // Custom scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery-datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                       "~/Scripts/custom/customers/customers-datatables-list.min.js",
                       "~/Scripts/DataTables/dataTables.jqueryui.min.js"));
            // Styles

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // Custom styles
            bundles.Add(new StyleBundle("~/datatables-custom-zi/css").Include(
                      "~/Content/DataTables/css/themes/jquery-datatables-zi-theme.css"));


            // FOR MINIFICATION !
            BundleTable.EnableOptimizations = true;

        }
    }
}