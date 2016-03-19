using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class NomenclaturesController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView();
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.Nomenclature connect = new Bm2s.Connectivity.Common.Article.Nomenclature();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Nomenclatures.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Nomenclature nomenclature)
    {
      Bm2s.Connectivity.Common.Article.Nomenclature connect = new Bm2s.Connectivity.Common.Article.Nomenclature();
      connect.Request.Nomenclature = nomenclature;
      connect.Post();

      return connect.Response.Nomenclatures.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public HtmlString DeleteValue(Nomenclature nomenclature)
    {
      Bm2s.Connectivity.Common.Article.Nomenclature connect = new Bm2s.Connectivity.Common.Article.Nomenclature();
      connect.Request.Nomenclature = nomenclature;
      connect.Delete();
      return true.ToHtmlJson();
    }
  }
}