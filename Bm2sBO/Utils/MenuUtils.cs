using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bm2sBO.Utils
{
  public static class MenuUtils
  {
    private static List<string> Split
    {
      get
      {
        return HttpContext.Current.Request.CurrentExecutionFilePath.Split('/').Where(item => !string.IsNullOrEmpty(item)).ToList();
      }
    }

    public static string Page
    {
      get
      {
        return MenuUtils.Split.LastOrDefault();
      }
    }

    public static string Section
    {
      get
      {
        return MenuUtils.Split.FirstOrDefault();
      }
    }
  }
}