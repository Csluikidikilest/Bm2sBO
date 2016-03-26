using Bm2sBO.Utils;
using System.Web.Mvc;

namespace Bm2sBO.Controllers
{
  public class LoginController : Controller
  {
    public ActionResult Index()
    {
      return PartialView();
    }

    [HttpPost]
    public int Index(string userLogin, string password)
    {
      return UserUtils.OpenSession(userLogin, password);
    }
  }
}