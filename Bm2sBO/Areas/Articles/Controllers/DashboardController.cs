using System.Web.Mvc;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class DashboardController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }
  }
}