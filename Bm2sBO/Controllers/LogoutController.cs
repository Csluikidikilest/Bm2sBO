using Bm2sBO.Utils;
using System.Web.Mvc;

namespace Bm2sBO.Controllers
{
  public class LogoutController : Controller
  {
    [HttpPost]
    public bool Index()
    {
      UserUtils.CloseSession();
      return UserUtils.CurrentUser.IsAnonymous;
    }
  }
}