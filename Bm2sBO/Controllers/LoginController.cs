using System.Web.Mvc;
using Bm2sBO.Models;

namespace Bm2sBO.Controllers
{
  public class LoginController : Controller
  {
    public ActionResult Index()
    {
      return PartialView(new LoginModel());
    }

    [HttpPost]
    public int Index(LoginModel model)
    {
      return model.OpenSession();
    }
  }
}