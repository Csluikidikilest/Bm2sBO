using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.User;
using Bm2sBO.Areas.Users.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Users.Controllers
{
  public class UsersController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View(new UsersModel());
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView(new UsersModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.User.User connect = new Bm2s.Connectivity.Common.User.User();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Users.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(User user)
    {
      Bm2s.Connectivity.Common.User.User connect = new Bm2s.Connectivity.Common.User.User();
      connect.Request.User = user;
      connect.Post();

      connect = new Bm2s.Connectivity.Common.User.User();
      connect.Request.Ids.Add(user.Id);
      connect.Get();
      return connect.Response.Users.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(User user)
    {
      Bm2s.Connectivity.Common.User.User connect = new Bm2s.Connectivity.Common.User.User();
      connect.Request.User = user;
      connect.Delete();

      return connect.Request.User.Id;
    }
  }
}