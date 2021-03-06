﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class SubFamiliesController : Controller
  {
    [HttpPost]
    public int DeleteValue(ArticleSubFamily articleSubFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.ArticleSubFamily = articleSubFamily;
      connect.Delete();

      return connect.Request.ArticleSubFamily.Id;
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
    public HtmlString SetValue(ArticleSubFamily articleSubFamily)
    {
      Bm2s.Connectivity.Common.Article.ArticleSubFamily connect = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
      connect.Request.ArticleSubFamily = articleSubFamily;
      connect.Post();

      SelectListUtils.ForceRefreshListSubFamily();

      return connect.Response.ArticleSubFamilies.FirstOrDefault().ToHtmlJson();
    }
  }
}