﻿using System.Web;
using System.Web.Optimization;

namespace Bm2sBO
{
  public class BundleConfig
  {
    // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/Lib/jquery.js",
                  "~/Scripts/Lib/jquery.select2.js"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/Lib/bootstrap.js"));

      bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/Lib/angular.js"));

      bundles.Add(new ScriptBundle("~/bundles/app").Include(
            "~/Scripts/App/bm2s.js"));

      bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
            "~/Scripts/Controllers/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/directives").Include(
            "~/Scripts/Directives/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/filters").Include(
            "~/Scripts/Filters/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/configurations").Include(
            "~/Scripts/Configurations/config." + System.Globalization.CultureInfo.CurrentCulture.Name.ToLower() + ".js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap.css"));

      bundles.Add(new LessBundle("~/Content/less").Include(
                "~/Content/site.less"));
    }
  }
}
