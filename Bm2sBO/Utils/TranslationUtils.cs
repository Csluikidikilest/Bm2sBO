using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Connectivity.Common.Parameter;

namespace Bm2sBO.Utils
{
  public static class TranslationUtils
  {
    public const string ApplicationName= "bm2sbo";

    public const string TranslationSessionKey = "translation";

    public static string Get(string screen, string key, string defaultValue, params string[] parameters)
    {
      return TranslationUtils.Get(screen, key, UserUtils.CurrentUser.DefaultLanguage, defaultValue);
    }

    public static string Get(string screen, string key, Bm2s.Poco.Common.Parameter.Language language, string defaultValue, params string[] parameters)
    {
      string result = (string)HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + screen + "_" + key + "_" + language.Id];

      if (string.IsNullOrWhiteSpace(result))
      {
        Translation translation = new Translation();
        translation.Request.Application = TranslationUtils.ApplicationName;
        translation.Request.LanguageId = language.Id;
        translation.Request.Screen = screen;
        translation.Request.Key = key;
        translation.Get();

        if (!translation.Response.Translations.Any())
        {
          translation.Request.Translation = new Bm2s.Poco.Common.Parameter.Translation()
          {
            Application = TranslationUtils.ApplicationName,
            Key = key,
            Language = language,
            Screen = screen,
            Value = "[" + language.Code + "_" + defaultValue + "]"
          };
          translation.Post();
        }

        result = translation.Response.Translations.FirstOrDefault().Value;
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + screen + "_" + key + "_" + language.Id] = result;
      }

      return string.Format(result, parameters);
    }

    public static string Get(string screen, string key, string languageCode, string defaultValue, params string[] parameters)
    {
      Language language = new Language();
      language.Request.Code = languageCode;
      language.Get();

      Bm2s.Poco.Common.Parameter.Language lang = language.Response.Languages.FirstOrDefault();

      if (lang == null)
      {
        lang = UserUtils.CurrentUser.DefaultLanguage;
      }

      return TranslationUtils.Get(screen, key, lang, defaultValue, parameters);
    }

    public static string Get(string screen, string key, int languageId, string defaultValue, params string[] parameters)
    {
      Language language = new Language();
      language.Request.Ids.Add(languageId);
      language.Get();

      Bm2s.Poco.Common.Parameter.Language lang = language.Response.Languages.FirstOrDefault();

      if (lang == null)
      {
        lang = UserUtils.CurrentUser.DefaultLanguage;
      }

      return TranslationUtils.Get(screen, key, lang, defaultValue, parameters);
    }

    public static IHtmlString TranslationLabelFor(this HtmlHelper helper, string screen, string key, string defaultValue, params string[] parameters)
    {
      return string.Format("<label id=\"{0}{1}\">{2}</label>", screen, key, TranslationUtils.Get(screen, key, defaultValue)).ToHtmlString();
    }

    public static IHtmlString TranslationFor(this HtmlHelper helper, string screen, string key, string defaultValue, params string[] parameters)
    {
      return TranslationUtils.Get(screen, key, defaultValue).ToHtmlString();
    }
  }
}