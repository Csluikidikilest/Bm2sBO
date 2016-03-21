using Bm2sBO.Utils;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Trade;

namespace Bm2sBO.Areas.Trades.Controllers
{
  public class PurchasesController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public PartialViewResult List()
    {
      return PartialView();
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Trade.Header connect = new Bm2s.Connectivity.Common.Trade.Header();
      connect.Request.IsPurchase = true;
      connect.Request.IsSell = false;
      connect.Get();

      return connect.Response.Headers.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Header purchase)
    {
      Bm2s.Connectivity.Common.Trade.Header connect = new Bm2s.Connectivity.Common.Trade.Header();
      connect.Request.Header = purchase;
      connect.Post();

      SelectListUtils.ForceRefreshListFamily();

      return connect.Response.Headers.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Header purchase)
    {
      Bm2s.Connectivity.Common.Trade.Header connect = new Bm2s.Connectivity.Common.Trade.Header();
      connect.Request.Header = purchase;
      connect.Delete();

      return connect.Request.Header.Id;
    }
  }
}