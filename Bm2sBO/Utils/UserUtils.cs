using Bm2s.Poco.Common.User;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bm2sBO.Utils
{
  public static class UserUtils
  {
    public const string UserSessionKey = "currentUser";

    public const string UserGroupSessionKey = "currentUserGroups";

    public static bool CanCreateArticles
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Articles);
      }
    }

    public static bool CanCreateBrands
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Brands);
      }
    }

    public static bool CanCreateFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Families);
      }
    }

    public static bool CanCreateGroups
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Groups);
      }
    }

    public static bool CanCreateModules
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Modules);
      }
    }

    public static bool CanCreateNomenclatures
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Nomenclatures);
      }
    }

    public static bool CanCreateParameters
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Parameters);
      }
    }

    public static bool CanCreatePartners
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Partners);
      }
    }

    public static bool CanCreatePrices
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Prices);
      }
    }

    public static bool CanCreatePurchases
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Purchases);
      }
    }

    public static bool CanCreateSales
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Sales);
      }
    }

    public static bool CanCreateSubFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.SubFamilies);
      }
    }

    public static bool CanCreateSubscriptions
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Subscriptions);
      }
    }

    public static bool CanCreateTrades
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Trades);
      }
    }

    public static bool CanCreateTranslations
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Translations);
      }
    }

    public static bool CanCreateUsers
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Create, Bm2sBO.Utils.Utils.Modules.Users);
      }
    }

    public static bool CanDeleteArticles
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Articles);
      }
    }

    public static bool CanDeleteBrands
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Brands);
      }
    }

    public static bool CanDeleteFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Families);
      }
    }

    public static bool CanDeleteGroups
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Groups);
      }
    }

    public static bool CanDeleteModules
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Modules);
      }
    }

    public static bool CanDeleteNomenclatures
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Nomenclatures);
      }
    }

    public static bool CanDeleteParameters
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Parameters);
      }
    }

    public static bool CanDeletePartners
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Partners);
      }
    }

    public static bool CanDeletePrices
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Prices);
      }
    }

    public static bool CanDeletePurchases
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Purchases);
      }
    }

    public static bool CanDeleteSales
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Sales);
      }
    }

    public static bool CanDeleteSubFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.SubFamilies);
      }
    }

    public static bool CanDeleteSubscriptions
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Subscriptions);
      }
    }

    public static bool CanDeleteTrades
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Trades);
      }
    }

    public static bool CanDeleteTranslations
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Translations);
      }
    }

    public static bool CanDeleteUsers
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Delete, Bm2sBO.Utils.Utils.Modules.Users);
      }
    }

    public static bool CanEditArticles
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Articles);
      }
    }

    public static bool CanEditBrands
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Brands);
      }
    }

    public static bool CanEditFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Families);
      }
    }

    public static bool CanEditGroups
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Groups);
      }
    }

    public static bool CanEditModules
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Modules);
      }
    }

    public static bool CanEditNomenclatures
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Nomenclatures);
      }
    }

    public static bool CanEditParameters
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Parameters);
      }
    }

    public static bool CanEditPartners
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Partners);
      }
    }

    public static bool CanEditPrices
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Prices);
      }
    }

    public static bool CanEditPurchases
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Purchases);
      }
    }

    public static bool CanEditSales
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Sales);
      }
    }

    public static bool CanEditSubFamilies
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.SubFamilies);
      }
    }

    public static bool CanEditSubscriptions
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Subscriptions);
      }
    }

    public static bool CanEditTrades
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Trades);
      }
    }

    public static bool CanEditTranslations
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Translations);
      }
    }

    public static bool CanEditUsers
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.Edit, Bm2sBO.Utils.Utils.Modules.Users);
      }
    }

    public static bool CanListArticles
    {
      get
      {
        return UserUtils.CanCreateArticles || UserUtils.CanDeleteArticles || UserUtils.CanEditArticles;
      }
    }

    public static bool CanListBrands
    {
      get
      {
        return UserUtils.CanCreateBrands || UserUtils.CanDeleteBrands || UserUtils.CanEditBrands;
      }
    }

    public static bool CanListFamilies
    {
      get
      {
        return UserUtils.CanCreateFamilies || UserUtils.CanDeleteFamilies || UserUtils.CanEditFamilies;
      }
    }

    public static bool CanListGroups
    {
      get
      {
        return UserUtils.CanCreateGroups || UserUtils.CanDeleteGroups || UserUtils.CanEditGroups;
      }
    }

    public static bool CanListModules
    {
      get
      {
        return UserUtils.CanCreateModules || UserUtils.CanDeleteModules || UserUtils.CanEditModules;
      }
    }

    public static bool CanListNomenclatures
    {
      get
      {
        return UserUtils.CanCreateNomenclatures || UserUtils.CanDeleteNomenclatures || UserUtils.CanEditNomenclatures;
      }
    }

    public static bool CanListParameters
    {
      get
      {
        return UserUtils.CanCreateParameters || UserUtils.CanDeleteParameters || UserUtils.CanEditParameters;
      }
    }

    public static bool CanListPartners
    {
      get
      {
        return UserUtils.CanCreatePartners || UserUtils.CanDeletePartners || UserUtils.CanEditPartners;
      }
    }

    public static bool CanListPrices
    {
      get
      {
        return UserUtils.CanCreatePrices || UserUtils.CanDeletePrices || UserUtils.CanEditPrices;
      }
    }

    public static bool CanListPurchases
    {
      get
      {
        return UserUtils.CanCreatePurchases || UserUtils.CanDeletePurchases || UserUtils.CanEditPurchases;
      }
    }

    public static bool CanListSales
    {
      get
      {
        return UserUtils.CanCreateSales || UserUtils.CanDeleteSales || UserUtils.CanEditSales;
      }
    }

    public static bool CanListSubFamilies
    {
      get
      {
        return UserUtils.CanCreateSubFamilies || UserUtils.CanDeleteSubFamilies || UserUtils.CanEditSubFamilies;
      }
    }

    public static bool CanListSubscriptions
    {
      get
      {
        return UserUtils.CanCreateSubscriptions || UserUtils.CanDeleteSubscriptions || UserUtils.CanEditSubscriptions;
      }
    }

    public static bool CanListTrades
    {
      get
      {
        return UserUtils.CanCreateTrades || UserUtils.CanDeleteTrades || UserUtils.CanEditTrades;
      }
    }

    public static bool CanListTranslations
    {
      get
      {
        return UserUtils.CanCreateTranslations || UserUtils.CanDeleteTranslations || UserUtils.CanEditTranslations;
      }
    }

    public static bool CanListUsers
    {
      get
      {
        return UserUtils.CanCreateUsers || UserUtils.CanDeleteUsers || UserUtils.CanEditUsers;
      }
    }

    public static bool CanViewDashboard
    {
      get
      {
        return AuthorizationUtils.HaveAuthorization(Authorizations.View, Bm2sBO.Utils.Utils.Modules.Dashboard);
      }
    }

    public static User CurrentUser
    {
      get
      {
        User currentUser = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          currentUser = (User)HttpContext.Current.Session[UserUtils.UserSessionKey];
        }

        if (currentUser == null)
        {
          Bm2s.Connectivity.Common.User.User user = new Bm2s.Connectivity.Common.User.User();
          user.Request.IsAnonymous = true;
          user.Get();
          currentUser = user.Response.Users.First();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[UserUtils.UserSessionKey] = currentUser;
          }
        }

        return currentUser;
      }
    }

    public static List<UserGroup> CurrentUserGroups
    {
      get
      {
        List<UserGroup> currentUserGroups = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          currentUserGroups = (List<UserGroup>)HttpContext.Current.Session[UserUtils.UserGroupSessionKey];
        }

        if (currentUserGroups == null)
        {
          Bm2s.Connectivity.Common.User.UserGroup userGroup = new Bm2s.Connectivity.Common.User.UserGroup();
          userGroup.Request.UserId = UserUtils.CurrentUser.Id;
          userGroup.Get();
          currentUserGroups = userGroup.Response.UserGroups;

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[UserUtils.UserGroupSessionKey] = currentUserGroups;
          }
        }

        return currentUserGroups;
      }
    }

    public static string CurrentUserLanguageCode
    {
      get
      {
        return (UserUtils.CurrentUser != null ? UserUtils.CurrentUser.DefaultLanguage.Code : System.Globalization.CultureInfo.CurrentCulture.Name).ToLower();
      }
    }

    public static void CloseSession()
    {
      HttpContext.Current.Session[UserUtils.UserSessionKey] = null;
      HttpContext.Current.Session[UserUtils.UserGroupSessionKey] = null;
      HttpContext.Current.Session[AuthorizationUtils.ModulesAuthorizationSessionKey] = null;
    }

    public static int OpenSession(string userLogin, string userPassword)
    {
      UserUtils.CloseSession();
      SHA512 hash = SHA512.Create();
      byte[] passwordBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(userPassword));

      StringBuilder password = new StringBuilder();
      foreach (byte passwordByte in passwordBytes)
      {
        password.Append(passwordByte.ToString("X2"));
      }

      Bm2s.Connectivity.Common.User.Login login = new Bm2s.Connectivity.Common.User.Login();
      login.Request.UserLogin = userLogin;
      login.Request.Password = password.ToString();
      login.Get();
      HttpContext.Current.Session[UserUtils.UserSessionKey] = login.Response.User;
      return login.Response.User.Id;
    }
  }
}
