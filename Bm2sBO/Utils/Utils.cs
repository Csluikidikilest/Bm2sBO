using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bm2s.Poco.Common.User;
using Bm2sBO.Models;
using ServiceStack.Text;

namespace Bm2sBO.Utils
{
  public static class Utils
  {
    public static User CurrentUser
    {
      get
      {
        var currentUser = HttpContext.Current.Session[LoginModel.SessionKey];
        if (currentUser == null)
        {
          Bm2s.Connectivity.Common.User.User user = new Bm2s.Connectivity.Common.User.User();
          user.Request.IsAnonymous = true;
          user.Get();
          currentUser = user.Response;
        }

        return (User)currentUser;
      }
    }

    public static HtmlString ToHtmlJson(this object value)
    {
      return new HtmlString(value.ToJson());
    }

    public static HtmlString ToHtmlString(this string value)
    {
      return new HtmlString(value);
    }

  }
}