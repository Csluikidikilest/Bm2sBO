using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Users.Controllers
{
  public class GroupsController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }
  }
}