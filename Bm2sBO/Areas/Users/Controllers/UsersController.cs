using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.User;
using Bm2sBO.Utils;
using System.Collections.Generic;

namespace Bm2sBO.Areas.Users.Controllers
{
  public class UsersController : Controller
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
      Bm2s.Connectivity.Common.User.User connect = new Bm2s.Connectivity.Common.User.User();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Users.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString GetGroupsUser(int userId)
    {
      Bm2s.Connectivity.Common.User.UserGroup connect = new Bm2s.Connectivity.Common.User.UserGroup();
      connect.Request.UserId = userId;
      connect.Get();

      return connect.Response.UserGroups.Select(item => item.Group.Id).ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(User user, List<int> groupsId)
    {
      Bm2s.Connectivity.Common.User.User connect = new Bm2s.Connectivity.Common.User.User();
      connect.Request.User = user;
      connect.Post();

      Bm2s.Connectivity.Common.User.UserGroup connectUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
      connectUserGroup.Request.UserId = user.Id;
      connectUserGroup.Get();

      Bm2s.Connectivity.Common.User.UserGroup removeUserGroup;
      foreach (UserGroup userGroup in connectUserGroup.Response.UserGroups.Where(item => !groupsId.Contains(item.Group.Id)))
      {
        removeUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        removeUserGroup.Request.UserGroup = userGroup;
        removeUserGroup.Delete();
      }

      Bm2s.Connectivity.Common.User.UserGroup addUserGroup;
      foreach (int groupId in groupsId.Where(item => !connectUserGroup.Response.UserGroups.Any(usgr => usgr.Group.Id == item)))
      {
        addUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        addUserGroup.Request.UserGroup = new Bm2s.Poco.Common.User.UserGroup();
        addUserGroup.Request.UserGroup.Group = new Bm2s.Poco.Common.User.Group();
        addUserGroup.Request.UserGroup.Group.Id = groupId;
        addUserGroup.Request.UserGroup.User = new Bm2s.Poco.Common.User.User();
        addUserGroup.Request.UserGroup.User.Id = user.Id;
        addUserGroup.Post();
      }

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