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
  public class GroupsController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View(new GroupsModel());
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView(new GroupsModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.User.Group connect = new Bm2s.Connectivity.Common.User.Group();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Groups.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Group group)
    {
      Bm2s.Connectivity.Common.User.Group connect = new Bm2s.Connectivity.Common.User.Group();
      connect.Request.Group = group;
      connect.Post();

      connect = new Bm2s.Connectivity.Common.User.Group();
      connect.Request.Ids.Add(group.Id);
      connect.Get();
      return connect.Response.Groups.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Group group)
    {
      Bm2s.Connectivity.Common.User.Group connect = new Bm2s.Connectivity.Common.User.Group();
      connect.Request.Group = group;
      connect.Delete();

      return connect.Request.Group.Id;
    }
  }
}