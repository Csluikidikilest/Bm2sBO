using System.Web;
using System.Web.Optimization;
using Bm2sBO.Utils;

namespace Bm2sBO
{
  public class BundleConfig
  {
    // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/Lib/jquery.js", "~/Scripts/Lib/jquery-ui.js", "~/Scripts/Lib/jquery.slimscroll.js"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/Lib/bootstrap.js"));

      bundles.Add(new ScriptBundle("~/bundles/adminlte").Include("~/Scripts/Lib/adminlte.js"));

      bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/Lib/angular.js", "~/Scripts/Lib/angular-ui-date.js", "~/Scripts/Lib/ngStorage.js"));

      bundles.Add(new ScriptBundle("~/bundles/chart").Include("~/Scripts/Lib/chart.js"));

      bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/App/bm2s.js"));

      bundles.Add(new ScriptBundle("~/bundles/controllers").Include("~/Scripts/Controllers/*.js", "~/Areas/Articles/Scripts/*.js", "~/Areas/Parameters/Scripts/*.js", "~/Areas/Partners/Scripts/*.js", "~/Areas/Trades/Scripts/*.js", "~/Areas/Users/Scripts/*.js", "~/Areas/Dashboard/Scripts/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/directives").Include("~/Scripts/Directives/Datatable/datatable.js", "~/Scripts/Directives/Edition/edition.js", "~/Scripts/Directives/InputFormat/inputFormat.js", "~/Scripts/Directives/Pagination/pagination.js", "~/Scripts/Directives/Selection/selection.js"));

      bundles.Add(new ScriptBundle("~/bundles/filters").Include("~/Scripts/Filters/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/configurations").Include("~/Scripts/Configurations/config." + UserUtils.CurrentUserLanguageCode.ToLower() + ".js"));

      bundles.Add(new StyleBundle("~/Content/csslib").Include("~/Content/Bootstrap/bootstrap.min.css", "~/Content/jQueryUi/*.css", "~/Content/FontAwesome/font-awesome.min.css", "~/Content/AdminLTE/AdminLTE.min.css", "~/Content/AdminLTE/skins/skin-blue.min.css"));

      bundles.Add(new LessBundle("~/Content/lessbm2s").Include("~/Content/bm2s.less"));
    }
  }
}
