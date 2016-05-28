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

      if (oldPrices != null)
      {
        if (oldPrices.All(price => !price.EndingDate.HasValue || newPrice.StartingDate > price.EndingDate.Value))
        {
          Price currentPrice = oldPrices.FirstOrDefault(price => !price.EndingDate.HasValue);
          if (currentPrice != null)
          {
            currentPrice.EndingDate = endingDatePrevious;
          }
        }
        else
        {
          Price currentPrice = oldPrices.FirstOrDefault(price => price.EndingDate > newPrice.StartingDate);
          DateTime? oldEndingDate = currentPrice.EndingDate;
          currentPrice.EndingDate = endingDatePrevious;
          if (newPrice.EndingDate.HasValue && oldEndingDate > newPrice.EndingDate.Value)
          {
            result.Add(new Price() { Article = currentPrice.Article, BasePrice = currentPrice.BasePrice, StartingDate = newPrice.EndingDate.Value.AddDays(1), EndingDate = oldEndingDate });
          }
        }

        result.AddRange(oldPrices);
      }

      result.Add(newPrice);

      return result.ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Article article)
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Delete();

      return connect.Request.Article.Id;
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
    public HtmlString SetPrice(Price price)
    {
      Bm2s.Connectivity.Common.Article.Price connect = new Bm2s.Connectivity.Common.Article.Price();
      connect.Request.Price = price;
      connect.Post();

      return connect.Response.Prices.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Article article, List<Price> prices)
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Post();

      Bm2s.Connectivity.Common.Article.Price connectPrice = new Bm2s.Connectivity.Common.Article.Price();
      foreach (Price price in prices)
      {
        price.Article = connect.Response.Articles.FirstOrDefault();
        connectPrice.Request.Price = price;
        connectPrice.Post();
      }

      return connect.Response.Articles.FirstOrDefault().ToHtmlJson();
    }
  }
}