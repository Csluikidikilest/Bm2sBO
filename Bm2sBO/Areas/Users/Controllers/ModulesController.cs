using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.User;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Users.Controllers
{
  public class ModulesController : Controller
  {
    [HttpGet]
    public ViewResult Index()
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
      Bm2s.Connectivity.Common.User.Module connect = new Bm2s.Connectivity.Common.User.Module();
      connect.Get();

      return connect.Response.Modules.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Module module)
    {
      Bm2s.Connectivity.Common.User.Module connect = new Bm2s.Connectivity.Common.User.Module();
      connect.Request.Module = module;
      connect.Post();

      return connect.Response.Modules.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Module module)
    {
      Bm2s.Connectivity.Common.User.Module connect = new Bm2s.Connectivity.Common.User.Module();
      connect.Request.Module = module;
      connect.Delete();

      return connect.Request.Module.Id;
    }
  }
}