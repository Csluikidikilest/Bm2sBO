using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Utils
{
  public static class SelectListUtils
  {
    public const string SelectListBrandSessionKey = "selectListBrand";

    public const string SelectListCurrencySessionKey = "selectListCurrency";

    public const string SelectListFamilySessionKey = "selectListFamily";

    public const string SelectListLanguageSessionKey = "selectListLanguage";

    public const string SelectListPeriodSessionKey = "selectListPeriod";

    public const string SelectListSubFamilySessionKey = "selectListSubFamily";

    public const string SelectListUnitSessionKey = "selectListUnit";

    public static HtmlString SelectListBrand
    {
      get
      {
        HtmlString selectListBrand = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListBrand = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListBrandSessionKey];
        }

        if (selectListBrand == null)
        {
          Bm2s.Connectivity.Common.Article.Brand brand = new Bm2s.Connectivity.Common.Article.Brand();
          brand.Get();
          selectListBrand = new { Brands = brand.Response.Brands.Select(item => new { Id = item.Id, Label = item.Name }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListBrandSessionKey] = selectListBrand;
          }
        }

        return selectListBrand;
      }
    }

    public static HtmlString SelectListCurrency
    {
      get
      {
        HtmlString selectListCurrency = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListCurrency = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListCurrencySessionKey];
        }

        if (selectListCurrency == null)
        {
          Bm2s.Connectivity.Common.Parameter.Unit unit = new Bm2s.Connectivity.Common.Parameter.Unit();
          unit.Get();
          selectListCurrency = new { Currencies = unit.Response.Units.Where(item => item.IsCurrency && !item.IsPeriod).Select(item => new { Id = item.Id, Label = item.Name }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListCurrencySessionKey] = selectListCurrency;
          }
        }

        return selectListCurrency;
      }
    }

    public static HtmlString SelectListFamily
    {
      get
      {
        HtmlString selectListFamily = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListFamily = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListFamilySessionKey];
        }

        if (selectListFamily == null)
        {
          Bm2s.Connectivity.Common.Article.ArticleFamily articleFamily = new Bm2s.Connectivity.Common.Article.ArticleFamily();
          articleFamily.Get();
          selectListFamily = new { ArticleFamilies = articleFamily.Response.ArticleFamilies.Select(item => new { Id = item.Id, Label = item.Designation }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListFamilySessionKey] = selectListFamily;
          }
        }

        return selectListFamily;
      }
    }

    public static HtmlString SelectListLanguage
    {
      get
      {
        HtmlString selectListLanguage = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListLanguage = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListLanguageSessionKey];
        }

        if (selectListLanguage == null)
        {
          Bm2s.Connectivity.Common.Parameter.Language language = new Bm2s.Connectivity.Common.Parameter.Language();
          language.Get();
          selectListLanguage = language.Response.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListLanguageSessionKey] = selectListLanguage;
          }
        }

        return selectListLanguage;
      }
    }

    public static HtmlString SelectListPeriod
    {
      get
      {
        HtmlString selectListPeriod = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListPeriod = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListPeriodSessionKey];
        }

        if (selectListPeriod == null)
        {
          Bm2s.Connectivity.Common.Parameter.Unit unit = new Bm2s.Connectivity.Common.Parameter.Unit();
          unit.Get();
          selectListPeriod = new { Periods = unit.Response.Units.Where(item => !item.IsCurrency && item.IsPeriod).Select(item => new { Id = item.Id, Label = item.Name }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListPeriodSessionKey] = selectListPeriod;
          }
        }

        return selectListPeriod;
      }
    }

    public static HtmlString SelectListSubFamily
    {
      get
      {
        HtmlString selectListSubFamily = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListSubFamily = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListSubFamilySessionKey];
        }

        if (selectListSubFamily == null)
        {
          Bm2s.Connectivity.Common.Article.ArticleSubFamily articleSubFamily = new Bm2s.Connectivity.Common.Article.ArticleSubFamily();
          articleSubFamily.Get();
          selectListSubFamily = new { ArticleFamilies = articleSubFamily.Response.ArticleSubFamilies.GroupBy(item => item.ArticleFamily.Id).Select(itemFamily => new { FamilyId = itemFamily.Key, ArticleSubFamilies = itemFamily.Select(itemSubFamily => new { Id = itemSubFamily.Id, Label = itemSubFamily.Designation }) }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListSubFamilySessionKey] = selectListSubFamily;
          }
        }

        return selectListSubFamily;
      }
    }

    public static HtmlString SelectListUnit
    {
      get
      {
        HtmlString selectListUnit = null;
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          selectListUnit = (HtmlString)HttpContext.Current.Session[SelectListUtils.SelectListUnitSessionKey];
        }

        if (selectListUnit == null)
        {
          Bm2s.Connectivity.Common.Parameter.Unit unit = new Bm2s.Connectivity.Common.Parameter.Unit();
          unit.Get();
          selectListUnit = new { Units = unit.Response.Units.Where(item => !item.IsCurrency && !item.IsPeriod).Select(item => new { Id = item.Id, Label = item.Name }) }.ToHtmlJson();

          if (HttpContext.Current != null && HttpContext.Current.Session != null)
          {
            HttpContext.Current.Session[SelectListUtils.SelectListUnitSessionKey] = selectListUnit;
          }
        }

        return selectListUnit;
      }
    }

    public static void ForceRefreshListBrand()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListBrandSessionKey] = null;
    }

    public static void ForceRefreshListCurrency()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListCurrencySessionKey] = null;
    }

    public static void ForceRefreshListFamily()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListFamilySessionKey] = null;
    }

    public static void ForceRefreshListLanguage()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListLanguageSessionKey] = null;
    }

    public static void ForceRefreshListPeriod()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListPeriodSessionKey] = null;
    }

    public static void ForceRefreshListSubFamily()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListSubFamilySessionKey] = null;
    }

    public static void ForceRefreshListUnit()
    {
      HttpContext.Current.Session[SelectListUtils.SelectListUnitSessionKey] = null;
    }
  }
}