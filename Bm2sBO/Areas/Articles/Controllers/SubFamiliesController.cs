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
    [HttpGet]
    public ActionResult Index()
    {
      return View(new SubFamiliesModel());
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView(new SubFamiliesModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

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
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.ArticleSubFamily = articleSubFamily;
      connect.Delete();

      return connect.Request.ArticleSubFamily.Id;
    }
  }
}