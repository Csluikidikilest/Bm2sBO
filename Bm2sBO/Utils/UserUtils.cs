using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bm2s.Poco.Common.User;
using Bm2sBO.Models;

namespace Bm2sBO.Utils
{
  public class UserUtils
  {
    public const string UserSessionKey = "currentUser";

    public const string UserGroupSessionKey = "currentUserGroups";

    public const string ModulesAuthorizationSessionKey = "modulesAuthorization";

    public static User CurrentUser
    {
      get
      {
        User currentUser = (User)HttpContext.Current.Session[UserUtils.UserSessionKey];
        if (currentUser == null)
        {
          Bm2s.Connectivity.Common.User.User user = new Bm2s.Connectivity.Common.User.User();
          user.Request.IsAnonymous = true;
          user.Get();
          currentUser = user.Response.Users.First();
          HttpContext.Current.Session[UserUtils.UserSessionKey] = currentUser;
        }

        return (User)currentUser;
      }
    }

    public static List<UserGroup> CurrentUserGroups
    {
      get
      {
        List<UserGroup> currentUserGroups = (List<UserGroup>)HttpContext.Current.Session[UserUtils.UserGroupSessionKey];
        if (currentUserGroups == null)
        {
          Bm2s.Connectivity.Common.User.UserGroup userGroup = new Bm2s.Connectivity.Common.User.UserGroup();
          userGroup.Request.UserId = UserUtils.CurrentUser.Id;
          userGroup.Get();
          currentUserGroups = userGroup.Response.UserGroups;
          HttpContext.Current.Session[UserUtils.UserGroupSessionKey] = currentUserGroups;
        }

        return (List<UserGroup>)currentUserGroups;
      }
    }

    public static List<Module> ModulesAuthorization
    {
      get
      {
        List<Module> modulesAuthorization = (List<Module>)HttpContext.Current.Session[UserUtils.ModulesAuthorizationSessionKey];
        if (modulesAuthorization == null)
        {
          Bm2s.Connectivity.Common.User.UserGroup userGroup = new Bm2s.Connectivity.Common.User.UserGroup();
          userGroup.Request.UserId = UserUtils.CurrentUser.Id;
          userGroup.Get();

          Bm2s.Connectivity.Common.User.GroupModule groupModule = new Bm2s.Connectivity.Common.User.GroupModule();
          foreach (UserGroup itemUserGroup in userGroup.Response.UserGroups)
          {
            groupModule.Request.GroupId = itemUserGroup.Id;
            groupModule.Get();
            foreach(GroupModule itemGroupModule in groupModule.Response.GroupModules.Where(itemModule => itemModule.Granted))
            {
              modulesAuthorization.Add(itemGroupModule.Module);
            }
          }

          Bm2s.Connectivity.Common.User.UserModule userModule = new Bm2s.Connectivity.Common.User.UserModule();
          userModule.Request.UserId = UserUtils.CurrentUser.Id;
          userModule.Get();

          foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => !itemModule.Granted))
          {
            modulesAuthorization.Remove(itemUserModule.Module);
          }

          foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => itemModule.Granted))
          {
            modulesAuthorization.Add(itemUserModule.Module);
          }
        }

        return modulesAuthorization;
      }
    }
  }
}
