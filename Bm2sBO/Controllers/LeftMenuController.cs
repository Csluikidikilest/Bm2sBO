using System.Web.Mvc;

namespace Bm2sBO.Controllers
{
    public class LeftMenuController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}