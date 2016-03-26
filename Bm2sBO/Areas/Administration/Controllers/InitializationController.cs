using Bm2sBO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Administration.Controllers
{
  public class InitializationController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public bool ModulesInitialization()
    {
      ModuleUtils.ModulesInitialization();
      return true;
    }
  }
}