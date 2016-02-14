using System.Web.Mvc;
using Bm2sBO.Areas.Articles.Models;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ArticlesController : Controller
  {
    public ActionResult Index()
    {
      return View(new ArticlesModel());
    }

    public ActionResult Edit(int articleId)
    {
      return View(new ArticlesModel(articleId));
    }

    public ActionResult Delete(int articleId)
    {
      return View(new ArticlesModel(articleId));
    }
  }
}