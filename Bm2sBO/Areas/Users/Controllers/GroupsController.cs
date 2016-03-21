using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.User;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Users.Controllers
{
  public class GroupsController : Controller
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
      Bm2s.Connectivity.Common.User.Group connect = new Bm2s.Connectivity.Common.User.Group();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Groups.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString GetUsersGroup(int groupId)
    {
      Bm2s.Connectivity.Common.User.UserGroup connect = new Bm2s.Connectivity.Common.User.UserGroup();
      connect.Request.GroupId = groupId;
      connect.Get();

      return connect.Response.UserGroups.Select(item => item.User.Id).ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Group group, List<int> usersId)
    {
      Bm2s.Connectivity.Common.User.Group connect = new Bm2s.Connectivity.Common.User.Group();
      connect.Request.Group = group;
      connect.Post();

      Bm2s.Connectivity.Common.User.UserGroup connectUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
      connectUserGroup.Request.GroupId = group.Id;
      connectUserGroup.Get();

      Bm2s.Connectivity.Common.User.UserGroup removeUserGroup;
      foreach (UserGroup userGroup in connectUserGroup.Response.UserGroups.Where(item => !usersId.Contains(item.User.Id)))
      {
        removeUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        removeUserGroup.Request.UserGroup = userGroup;
        removeUserGroup.Delete();
      }

      Bm2s.Connectivity.Common.User.UserGroup addUserGroup;
      foreach (int userId in usersId.Where(item => !connectUserGroup.Response.UserGroups.Any(ug => ug.User.Id == item)))
      {
        addUserGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        addUserGroup.Request.UserGroup = new Bm2s.Poco.Common.User.UserGroup();
        addUserGroup.Request.UserGroup.Group = new Bm2s.Poco.Common.User.Group();
        addUserGroup.Request.UserGroup.Group.Id = group.Id;
        addUserGroup.Request.UserGroup.User = new Bm2s.Poco.Common.User.User();
        addUserGroup.Request.UserGroup.User.Id = userId;
        addUserGroup.Post();
      }

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