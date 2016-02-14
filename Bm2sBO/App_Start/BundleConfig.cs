using System.Web;
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

      bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                "~/Scripts/Lib/adminlte.js"));

      bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/Lib/angular.js"));

      bundles.Add(new ScriptBundle("~/bundles/app").Include(
            "~/Scripts/App/bm2s.js"));

      bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
            "~/Scripts/Controllers/*.js",
            "~/Areas/Articles/Scripts/*.js",
            "~/Areas/Parameters/Scripts/*.js",
            "~/Areas/Partners/Scripts/*.js",
            "~/Areas/Trades/Scripts/*.js",
            "~/Areas/Users/Scripts/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/directives").Include(
            "~/Scripts/Directives/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/filters").Include(
            "~/Scripts/Filters/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/configurations").Include(
            "~/Scripts/Configurations/config." + System.Globalization.CultureInfo.CurrentCulture.Name.ToLower() + ".js"));

      bundles.Add(new StyleBundle("~/Content/csslib").Include(
                "~/Content/Bootstrap/bootstrap.min.css",
                "~/Content/FontAwesome/font-awesome.min.css",
                "~/Content/AdminLTE/AdminLTE.min.css",
                "~/Content/AdminLTE/skins/skin-blue.min.css"));

      bundles.Add(new LessBundle("~/Content/lessbm2s").Include(
                "~/Content/bm2s.less"));
    }
  }
}
