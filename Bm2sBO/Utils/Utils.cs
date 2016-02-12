using System.Web;
using ServiceStack.Text;

namespace Bm2sBO.Utils
{
  public static class Utils
  {
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