using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ArticlesController : Controller
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
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Articles.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Article article)
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Post();

      return connect.Response.Articles.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Article article)
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Delete();

      return connect.Request.Article.Id;
    }
  }
}