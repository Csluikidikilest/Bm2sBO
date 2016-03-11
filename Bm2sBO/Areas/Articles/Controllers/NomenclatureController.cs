using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Areas.Articles.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class NomenclatureController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new NomenclatureModel());
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView(new NomenclatureModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Get();

      return connect.Response.Articles.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Nomenclature nomenclature)
    {
      Bm2s.Connectivity.Common.Article.Nomenclature connect = new Bm2s.Connectivity.Common.Article.Nomenclature();
      connect.Request.Nomenclature = nomenclature;
      connect.Post();

      connect = new Bm2s.Connectivity.Common.Article.Nomenclature();
      connect.Request.Ids.Add(nomenclature.Id);
      connect.Get();
      return connect.Response.Nomenclatures.FirstOrDefault().ToHtmlJson();
    }
  }
}