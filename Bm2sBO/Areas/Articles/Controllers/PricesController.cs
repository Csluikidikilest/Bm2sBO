using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class PricesController : Controller
  {
    [HttpGet]
    public ActionResult Index()
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
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Prices.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Price price)
    {
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      connect.Request.Price = price;
      connect.Post();

      return connect.Response.Prices.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Price price)
    {
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      connect.Request.Price = price;
      connect.Delete();

      return connect.Request.Price.Id;
    }
  }
}