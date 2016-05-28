using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ArticleFamiliesController : Controller
  {
    [HttpPost]
    public int DeleteValue(ArticleFamily articleFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      connect.Request.ArticleFamily = articleFamily;
      connect.Delete();

      return connect.Request.ArticleFamily.Id;
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.ArticleFamilies.ToHtmlJson();
    }

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
    public HtmlString SetValue(ArticleFamily articleFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleFamily connect = new Bm2s.Connectivity.Common.Article.ArticleFamily();
      connect.Request.ArticleFamily = articleFamily;
      connect.Post();

      SelectListUtils.ForceRefreshListFamily();

      return connect.Response.ArticleFamilies.FirstOrDefault().ToHtmlJson();
    }
  }
}