using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Connectivity.Common.Parameter;

namespace Bm2sBO.Utils
{
  public class ParameterUtils
  {
    public const string ParameterSessionKey = "parameter";

    public static bool Get(string code, bool defaultValue)
    {
      string result = (string)HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code];

      if (string.IsNullOrWhiteSpace(result))
      {
        Parameter parameter = new Parameter();
        parameter.Request.Code = code;
        parameter.Get();

        if (!parameter.Response.Parameters.Any())
        {
          parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
          {
            Code = code,
            ValueType = "b",
            bValue = defaultValue
          };

          parameter.Post();
        }

        result = parameter.Response.Parameters.FirstOrDefault().bValue.ToString().ToLower();
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + code] = result;
      }

      return result == true.ToString().ToLower();
    }

    public static DateTime Get(string code, DateTime defaultValue)
    {
      string result = (string)HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code];

      if (string.IsNullOrWhiteSpace(result))
      {
        Parameter parameter = new Parameter();
        parameter.Request.Code = code;
        parameter.Get();

        if (!parameter.Response.Parameters.Any())
        {
          parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
          {
            Code = code,
            ValueType = "d",
            dValue = defaultValue
          };

          parameter.Post();
        }

        result = parameter.Response.Parameters.FirstOrDefault().dValue.ToString();
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + code] = result;
      }

      return DateTime.Parse(result);
    }

    public static float Get(string code, float defaultValue)
    {
      string result = (string)HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code];

      if (string.IsNullOrWhiteSpace(result))
      {
        Parameter parameter = new Parameter();
        parameter.Request.Code = code;
        parameter.Get();

        if (!parameter.Response.Parameters.Any())
        {
          parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
          {
            Code = code,
            ValueType = "f",
            fValue = defaultValue
          };

          parameter.Post();
        }

        result = parameter.Response.Parameters.FirstOrDefault().fValue.ToString();
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + code] = result;
      }

      return float.Parse(result);
    }

    public static int Get(string code, int defaultValue)
    {
      string result = (string)HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code];

      if (string.IsNullOrWhiteSpace(result))
      {
        Parameter parameter = new Parameter();
        parameter.Request.Code = code;
        parameter.Get();

        if (!parameter.Response.Parameters.Any())
        {
          parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
          {
            Code = code,
            ValueType = "i",
            iValue = defaultValue
          };

          parameter.Post();
        }

        result = parameter.Response.Parameters.FirstOrDefault().iValue.ToString();
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + code] = result;
      }

      return int.Parse(result);
    }

    public static string Get(string code, string defaultValue)
    {
      string result = (string)HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code];

      if (string.IsNullOrWhiteSpace(result))
      {
        Parameter parameter = new Parameter();
        parameter.Request.Code = code;
        parameter.Get();

        if (!parameter.Response.Parameters.Any())
        {
          parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
          {
            Code = code,
            ValueType = "s",
            sValue = defaultValue
          };

          parameter.Post();
        }

        result = parameter.Response.Parameters.FirstOrDefault().sValue;
        HttpContext.Current.Session[TranslationUtils.TranslationSessionKey + "_" + code] = result;
      }

      return result;
    }
  }
}
