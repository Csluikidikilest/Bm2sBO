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

    public static string Get(string code, string description, bool isOverloadable, bool defaultValue)
    {
      string result = (HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] as string);

      if (string.IsNullOrWhiteSpace(result))
      {
        ParameterUtils.Set(code, description, isOverloadable, defaultValue);
        result = defaultValue.ToString();
      }

      return result.ToLower();
    }

    public static string Get(string code, string description, bool isOverloadable, DateTime? defaultValue)
    {
      string result = (HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] as string);

      if (string.IsNullOrWhiteSpace(result))
      {
        ParameterUtils.Set(code, description, isOverloadable, defaultValue);
        result = defaultValue.ToString();
      }

      return result;
    }

    public static string Get(string code, string description, bool isOverloadable, decimal defaultValue)
    {
      string result = (HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] as string);

      if (string.IsNullOrWhiteSpace(result))
      {
        ParameterUtils.Set(code, description, isOverloadable, defaultValue);
        result = defaultValue.ToString();
      }

      return result.Replace(',', '.');
    }

    public static string Get(string code, string description, bool isOverloadable, int defaultValue)
    {
      string result = (HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] as string);

      if (string.IsNullOrWhiteSpace(result))
      {
        ParameterUtils.Set(code, description, isOverloadable, defaultValue);
        result = defaultValue.ToString();
      }

      return result;
    }

    public static string Get(string code, string description, bool isOverloadable, string defaultValue)
    {
      string result = (HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] as string);

      if (string.IsNullOrWhiteSpace(result))
      {
        ParameterUtils.Set(code, description, isOverloadable, defaultValue);
        result = defaultValue;
      }

      return result;
    }

    public static void Set(string code, string description, bool isOverloadable, bool value)
    {
      Parameter parameter = new Parameter();
      parameter.Request.Code = code;
      parameter.Get();

      if (!parameter.Response.Parameters.Any())
      {
        parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
        {
          Code = code,
          Description = description,
          ValueType = "b",
          bValue = value,
          IsSystem = false,
          IsOverloadable = isOverloadable
        };

        parameter.Post();
      }
      else
      {
        parameter.Request.Parameter = parameter.Response.Parameters.First();
        parameter.Request.Parameter.Code = code;
        parameter.Request.Parameter.Description = description;
        parameter.Request.Parameter.ValueType = "b";
        parameter.Request.Parameter.bValue = value;
        parameter.Request.Parameter.IsOverloadable = isOverloadable;
      }

      HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] = value;
    }

    public static void Set(string code, string description, bool isOverloadable, DateTime? value)
    {
      Parameter parameter = new Parameter();
      parameter.Request.Code = code;
      parameter.Get();

      if (!parameter.Response.Parameters.Any())
      {
        parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
        {
          Code = code,
          Description = description,
          ValueType = "d",
          dValue = value,
          IsSystem = false,
          IsOverloadable = isOverloadable
        };

        parameter.Post();
      }
      else
      {
        parameter.Request.Parameter = parameter.Response.Parameters.First();
        parameter.Request.Parameter.Code = code;
        parameter.Request.Parameter.Description = description;
        parameter.Request.Parameter.ValueType = "d";
        parameter.Request.Parameter.dValue = value;
        parameter.Request.Parameter.IsOverloadable = isOverloadable;
      }

      HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] = value;
    }

    public static void Set(string code, string description, bool isOverloadable, decimal value)
    {
      Parameter parameter = new Parameter();
      parameter.Request.Code = code;
      parameter.Get();

      if (!parameter.Response.Parameters.Any())
      {
        parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
        {
          Code = code,
          Description = description,
          ValueType = "f",
          fValue = value,
          IsSystem = false,
          IsOverloadable = isOverloadable
        };

        parameter.Post();
      }
      else
      {
        parameter.Request.Parameter = parameter.Response.Parameters.First();
        parameter.Request.Parameter.Code = code;
        parameter.Request.Parameter.Description = description;
        parameter.Request.Parameter.ValueType = "f";
        parameter.Request.Parameter.fValue = value;
        parameter.Request.Parameter.IsOverloadable = isOverloadable;
      }

      HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] = value;
    }

    public static void Set(string code, string description, bool isOverloadable, int value)
    {
      Parameter parameter = new Parameter();
      parameter.Request.Code = code;
      parameter.Get();

      if (!parameter.Response.Parameters.Any())
      {
        parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
        {
          Code = code,
          Description = description,
          ValueType = "i",
          iValue = value,
          IsSystem = false,
          IsOverloadable = isOverloadable
        };

        parameter.Post();
      }
      else
      {
        parameter.Request.Parameter = parameter.Response.Parameters.First();
        parameter.Request.Parameter.Code = code;
        parameter.Request.Parameter.Description = description;
        parameter.Request.Parameter.ValueType = "i";
        parameter.Request.Parameter.iValue = value;
        parameter.Request.Parameter.IsOverloadable = isOverloadable;
      }

      HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] = value;
    }

    public static void Set(string code, string description, bool isOverloadable, string value)
    {
      Parameter parameter = new Parameter();
      parameter.Request.Code = code;
      parameter.Get();

      if (!parameter.Response.Parameters.Any())
      {
        parameter.Request.Parameter = new Bm2s.Poco.Common.Parameter.Parameter()
        {
          Code = code,
          Description = description,
          ValueType = "s",
          sValue = value,
          IsSystem = false,
          IsOverloadable = isOverloadable
        };

        parameter.Post();
      }
      else
      {
        parameter.Request.Parameter = parameter.Response.Parameters.First();
        parameter.Request.Parameter.Code = code;
        parameter.Request.Parameter.Description = description;
        parameter.Request.Parameter.ValueType = "s";
        parameter.Request.Parameter.sValue = value;
        parameter.Request.Parameter.IsOverloadable = isOverloadable;
      }

      HttpContext.Current.Session[ParameterUtils.ParameterSessionKey + "_" + code] = value;
    }
  }
}
