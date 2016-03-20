using Bm2s.Poco.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bm2sBO.Utils
{
  public static class AuthorizationUtils
  {
    public const string ModulesAuthorizationSessionKey = "modulesAuthorization";

    public static bool HaveAuthorization(Authorizations authorization, Bm2sBO.Utils.Utils.Modules module)
    {
      return AuthorizationUtils.HaveAuthorization(UserUtils.CurrentUser.Id, authorization, module);
    }

    public static bool HaveAuthorization(int userId, Authorizations authorization, Bm2sBO.Utils.Utils.Modules module)
    {
      Bm2s.Connectivity.Common.User.User user = new Bm2s.Connectivity.Common.User.User();
      user.Request.Ids.Add(userId);
      user.Get();
      return AuthorizationUtils.HaveAuthorization(user.Response.Users.FirstOrDefault(), authorization, module);
    }

    public static bool HaveAuthorization(User user, Authorizations authorization, Bm2sBO.Utils.Utils.Modules module)
    {
      return user != null && (user.IsAdministrator || AuthorizationUtils.ModulesAuthorization(user.Id).Any(item => item.Code.ToLower() == (authorization.ToString() + module.ToString()).ToLower()));
    }

    public static List<Module> ModulesAuthorization()
    {
      return ModulesAuthorization(UserUtils.CurrentUser.Id);
    }

    public static List<Module> ModulesAuthorization(int userId)
    {
      List<Module> modulesAuthorization = (List<Module>)HttpContext.Current.Session[AuthorizationUtils.ModulesAuthorizationSessionKey + "_" + userId.ToString()];
      if (modulesAuthorization == null)
      {
        modulesAuthorization = new List<Module>();
        Bm2s.Connectivity.Common.User.UserGroup userGroup = new Bm2s.Connectivity.Common.User.UserGroup();
        userGroup.Request.UserId = userId;
        userGroup.Get();

        Bm2s.Connectivity.Common.User.GroupModule groupModule = new Bm2s.Connectivity.Common.User.GroupModule();
        foreach (UserGroup itemUserGroup in userGroup.Response.UserGroups.Where(group => !group.Group.EndingDate.HasValue || group.Group.EndingDate.Value > DateTime.Now))
        {
          groupModule.Request.GroupId = itemUserGroup.Id;
          groupModule.Get();
          foreach (GroupModule itemGroupModule in groupModule.Response.GroupModules.Where(itemModule => itemModule.Granted))
          {
            modulesAuthorization.Add(itemGroupModule.Module);
          }
        }

        Bm2s.Connectivity.Common.User.UserModule userModule = new Bm2s.Connectivity.Common.User.UserModule();
        userModule.Request.UserId = userId;
        userModule.Get();

        foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => !itemModule.Granted))
        {
          modulesAuthorization.Remove(itemUserModule.Module);
        }

        foreach (UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => itemModule.Granted))
        {
          modulesAuthorization.Add(itemUserModule.Module);
        }

        HttpContext.Current.Session[AuthorizationUtils.ModulesAuthorizationSessionKey + "_" + userId.ToString()] = modulesAuthorization;
      }

      return modulesAuthorization;
    }
  }

  public enum Authorizations
  {
    Create,
    Delete,
    Edit,
    View,
  }
}