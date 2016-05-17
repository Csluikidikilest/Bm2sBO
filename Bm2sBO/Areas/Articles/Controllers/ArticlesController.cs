using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Text;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ArticlesController : Controller
  {
    [HttpPost]
    public HtmlString AddPrice(List<Price> oldPrices, Price newPrice)
    {
      List<Price> result = new List<Price>();
      DateTime endingDatePrevious = newPrice.StartingDate.AddDays(-1);

      if (oldPrices.All(price => !price.EndingDate.HasValue || newPrice.StartingDate > price.EndingDate.Value))
      {
        Price currentPrice = oldPrices.FirstOrDefault(price => !price.EndingDate.HasValue);
        if (currentPrice != null)
        {
          currentPrice.EndingDate = endingDatePrevious;
        }
        result.AddRange(oldPrices);
        result.Add(newPrice);
      }
      else
      {

      }

      return result.ToHtmlJson();
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
    public HtmlString GetPrices(int articleId)
    {
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      connect.Request.ArticleId = articleId;
      connect.Get();

      return connect.Response.Prices.ToHtmlJson();
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
    public HtmlString SetPrice(Price price)
    {
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      connect.Request.Price = price;
      connect.Post();

      return connect.Response.Prices.FirstOrDefault().ToHtmlJson();
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