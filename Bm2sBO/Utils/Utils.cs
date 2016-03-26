using System.Web;
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
  }
}