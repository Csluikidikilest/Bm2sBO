using System.Web.Mvc;
using Bm2sBO.Models;

namespace Bm2sBO.Controllers
{
  public class ArticleController : Controller
  {
    public ActionResult Index()
    {
      return View(new ArticleModel());
    }

    public ActionResult Edit(int articleId)
    {
      return View(new ArticleModel(articleId));
    }
  }
}