using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Areas.Articles.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class FamiliesController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new FamiliesModel());
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView(new FamiliesModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      connect.Get();

      return connect.Response.ArticleFamilies.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(ArticleFamily articleFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      connect.Request.ArticleFamily = articleFamily;
      connect.Post();

      SelectListUtils.ForceRefreshListFamily();

      return connect.Response.ArticleFamilies.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(ArticleFamily articleFamily)
    {
      articleFamily.EndingDate = DateTime.Now;

      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      connect.Request.ArticleFamily = articleFamily;
      connect.Post();

      return connect.Request.ArticleFamily.Id;
    }
  }
}