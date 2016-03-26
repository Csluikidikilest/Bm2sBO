using Bm2s.Connectivity.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bm2sBO.Utils
{
  public class ModuleUtils
  {
    public const string ModulesSessionKey = "modules";

    public static bool HaveAuthorization(Authorizations authorization, Bm2sBO.Utils.Modules module)
    {
      return ModuleUtils.HaveAuthorization(UserUtils.CurrentUser.Id, authorization, module);
    }

    public static bool HaveAuthorization(int userId, Authorizations authorization, Bm2sBO.Utils.Modules module)
    {
      User user = new User();
      user.Request.Ids.Add(userId);
      user.Get();
      return ModuleUtils.HaveAuthorization(user.Response.Users.FirstOrDefault(), authorization, module);
    }

    public static bool HaveAuthorization(Bm2s.Poco.Common.User.User user, Authorizations authorization, Bm2sBO.Utils.Modules module)
    {
      return user != null && (user.IsAdministrator || ModuleUtils.ModulesAuthorization(user.Id).Any(item => item.Code.ToLower() == (authorization.ToString() + "_" + module.ToString()).ToLower() && (!item.EndingDate.HasValue || item.EndingDate.Value < DateTime.Now.Date)));
    }

    public static void ModulesInitialization()
    {
      Module connect;

      foreach (Authorizations authorization in Enum.GetValues(typeof(Authorizations)))
      {
        foreach (Modules module in Enum.GetValues(typeof(Modules)))
        {
          connect = new Module();
          connect.Request.Code = (authorization.ToString() + "_" + module.ToString()).ToLower();
          connect.Get();

          if (!connect.Response.Modules.Any())
          {
            connect.Request.Module = new Bm2s.Poco.Common.User.Module()
            {
              Code = (authorization.ToString() + "_" + module.ToString()).ToLower(),
              Description = "Right to " + authorization.ToString().ToLower() + " " + module.ToString().ToLower(),
              EndingDate = null,
              Name = "Right to " + authorization.ToString().ToLower() + " " + module.ToString().ToLower(),
              StartingDate = new DateTime(2015, 1, 1),
            };
            connect.Post();
          }
        }
      }
    }

    public static bool NeedModulesInitialization
    {
      get
      {
        Module connect = new Module();
        connect.Get();
        return !connect.Response.Modules.Any();
      }
    }

    public static List<Bm2s.Poco.Common.User.Module> ModulesAuthorization()
    {
      return ModulesAuthorization(UserUtils.CurrentUser.Id);
    }

    public static List<Bm2s.Poco.Common.User.Module> ModulesAuthorization(int userId)
    {
      List<Bm2s.Poco.Common.User.Module> modulesAuthorization = new List<Bm2s.Poco.Common.User.Module>();
      UserGroup userGroup = new UserGroup();
      userGroup.Request.UserId = userId;
      userGroup.Get();

      GroupModule groupModule = new GroupModule();
      foreach (Bm2s.Poco.Common.User.UserGroup itemUserGroup in userGroup.Response.UserGroups.Where(group => !group.Group.EndingDate.HasValue || group.Group.EndingDate.Value > DateTime.Now))
      {
        groupModule.Request.GroupId = itemUserGroup.Id;
        groupModule.Get();
        foreach (Bm2s.Poco.Common.User.GroupModule itemGroupModule in groupModule.Response.GroupModules.Where(itemModule => itemModule.Granted))
        {
          modulesAuthorization.Add(itemGroupModule.Module);
        }
      }

      UserModule userModule = new UserModule();
      userModule.Request.UserId = userId;
      userModule.Get();

      foreach (Bm2s.Poco.Common.User.UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => !itemModule.Granted))
      {
        modulesAuthorization.Remove(itemUserModule.Module);
      }

      foreach (Bm2s.Poco.Common.User.UserModule itemUserModule in userModule.Response.UserModules.Where(itemModule => itemModule.Granted))
      {
        modulesAuthorization.Add(itemUserModule.Module);
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

  public enum Modules
  {
    Articles,
    Brands,
    Dashboard,
    Families,
    Groups,
    Modules,
    Nomenclatures,
    Parameters,
    Partners,
    Prices,
    Purchases,
    Sales,
    SubFamilies,
    Subscriptions,
    Trades,
    Translations,
    Users,
  }
}