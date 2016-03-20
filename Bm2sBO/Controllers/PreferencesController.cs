using Bm2sBO.Utils;
using System.Web.Mvc;

namespace Bm2sBO.Controllers
{
  public class PreferencesController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return PartialView();
    }

    [HttpPost]
    public bool Index(int languageId, string firstName, string lastName)
    {
      Bm2s.Poco.Common.User.User currentUser = UserUtils.CurrentUser;
      currentUser.DefaultLanguage.Id = languageId;
      currentUser.FirstName = firstName;
      currentUser.LastName = lastName;
      return true;
    }
  }
}