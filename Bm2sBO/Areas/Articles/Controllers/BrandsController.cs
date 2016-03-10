using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Areas.Articles.Models;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class BrandsController : Controller
  {
    public ActionResult Index()
    {
      return View(new BrandsModel());
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Article.Brand connect = new Bm2s.Connectivity.Common.Article.Brand();
      connect.Get();

      return connect.Response.Brands.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString SetValue(Brand brand)
    {
      Bm2s.Connectivity.Common.Article.Brand connect = new Bm2s.Connectivity.Common.Article.Brand();
      connect.Request.Brand = brand;
      connect.Post();

      SelectListUtils.ForceRefreshListFamily();

      return connect.Response.Brands.FirstOrDefault().ToHtmlJson();
    }

    [HttpPost]
    public int DeleteValue(Brand brand)
    {
      brand.EndingDate = DateTime.Now;

      Bm2s.Connectivity.Common.Article.Brand connect = new Bm2s.Connectivity.Common.Article.Brand();
      connect.Request.Brand = brand;
      connect.Post();

      return connect.Request.Brand.Id;
    }
  }
}