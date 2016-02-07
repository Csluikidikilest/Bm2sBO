using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Connectivity.Common.Article;
using Bm2sBO.Models;

namespace Bm2sBO.Controllers
{
  public class ArticleController : Controller
  {
    // GET: Article
    public ActionResult Index()
    {
      return View(new ArticleModel());
    }

    // GET: Article
    [HttpGet]
    public ActionResult Index(ArticleModel model)
    {
      model.Get();
      return View(model);
    }

    // POST: Article
    [HttpPost]
    public ActionResult Save(ArticleModel model)
    {
      model.Post();
      return View(model);
    }
  }
}