using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Connectivity.Common.Parameter;
using Bm2sBO.Areas.Parameters.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Parameters.Controllers
{
  public class TranslationsController : Controller
  {
    public ActionResult Index()
    {
      return View(new TranslationsModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Language language = new Language();
      language.Get();

      Translation translation = new Translation();
      translation.Request.PageSize = 0;
      translation.Get();

      var result = translation.Response.Translations.Where(tran => tran.Application == TranslationUtils.ApplicationName).Select(tran => new { Screen = tran.Screen, Key = tran.Key, Languages = language.Response.Languages.Select(lang => new { Code = lang.Code, Translation = TranslationUtils.Get(tran.Screen, tran.Key, lang, string.Empty) }) });

      return result.ToHtmlJson();
    }

    [HttpPost]
    public int SetValue(string screen, string key, int languageId, string value)
    {
      Language language = new Language();
      language.Request.Ids.Add(languageId);
      language.Get();

      Translation translation = new Translation();
      translation.Request.Application = TranslationUtils.ApplicationName;
      translation.Request.Screen = screen;
      translation.Request.Key = key;
      translation.Request.LanguageId = languageId;
      translation.Get();
      Bm2s.Poco.Common.Parameter.Translation tran = translation.Response.Translations.FirstOrDefault();

      translation.Request.Translation.Application = TranslationUtils.ApplicationName;
      translation.Request.Translation.Screen = screen;
      translation.Request.Translation.Key = key;
      translation.Request.Translation.Language = language.Response.Languages.FirstOrDefault();
      translation.Request.Translation.Value = value;
      if (tran != null)
      {
        translation.Request.Translation.Id = tran.Id;
      }
      translation.Post();

      return translation.Response.Translations.FirstOrDefault().Id;
    }
  }
}