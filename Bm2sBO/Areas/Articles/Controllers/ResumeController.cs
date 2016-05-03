using System.Web.Mvc;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class ResumeController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }
  }
}