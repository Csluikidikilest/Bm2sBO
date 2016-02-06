using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    [HttpPost]
    public ActionResult Index(ArticleModel model)
    {
      model.Post();
      return View(model);
    }
  }
}