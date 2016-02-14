using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Bm2s.Response;
using ServiceStack.Text;

namespace Bm2sBO.Utils
{
  public static class Utils
  {
    public static HtmlString ToHtmlJson(this object value)
    {
      return value.ToJson().ToHtmlString();
    }

    public static HtmlString ToHtmlString(this object value)
    {
      return new HtmlString(value.ToString());
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
}