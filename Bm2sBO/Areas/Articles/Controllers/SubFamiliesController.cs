using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Areas.Articles.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class SubFamiliesController : Controller
  {
    public ActionResult Index()
    {
      return View(new SubFamiliesModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Get();

      return connect.Response.ArticleSubFamilies.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(ArticleSubFamily articleSubFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.ArticleSubFamily = articleSubFamily;
      connect.Post();

      SelectListUtils.ForceRefreshListSubFamily();

      connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.Ids.Add(articleSubFamily.Id);
      connect.Get();
      return connect.Response.ArticleSubFamilies.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(ArticleSubFamily articleSubFamily)
    {
      articleSubFamily.EndingDate = DateTime.Now;

      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.ArticleSubFamily = articleSubFamily;
      connect.Post();

      return connect.Request.ArticleSubFamily.Id;
    }
  }
}