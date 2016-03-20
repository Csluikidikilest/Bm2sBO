using Bm2s.Poco.Common.Parameter;
using Bm2sBO.Utils;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Parameters.Controllers
{
  public class ParametersController : Controller
  {
    // GET: Parameters/Parameters
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView();
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Parameter.Parameter connect = new Bm2s.Connectivity.Common.Parameter.Parameter();
      connect.Get();

      return connect.Response.Parameters.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Parameter parameter)
    {
      Bm2s.Connectivity.Common.Parameter.Parameter connect = new Bm2s.Connectivity.Common.Parameter.Parameter();
      connect.Request.Parameter = parameter;
      connect.Post();

      return connect.Response.Parameters.FirstOrDefault().ToHtmlJson();
    }
  }
}