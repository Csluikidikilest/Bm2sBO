﻿using System;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Areas.Articles.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ArticlesController : Controller
  {
    public ActionResult Index()
    {
      return View(new ArticlesModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.Article article = new Bm2s.Connectivity.Common.Article.Article();
      article.Get();
      return article.Response.ToHtmlJson();
    }

    [HttpPost]
    public int SetValue(Article article)
    {
      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Post();

      return connect.Request.Article.Id;
    }

    [HttpPost]
    public int DeleteValue(Article article)
    {
      article.EndingDate = DateTime.Now;

      Bm2s.Connectivity.Common.Article.Article connect = new Bm2s.Connectivity.Common.Article.Article();
      connect.Request.Article = article;
      connect.Post();

      return connect.Request.Article.Id;
    }
  }
}