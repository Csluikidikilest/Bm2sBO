using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2s.Poco.Common.Article;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class BrandsController : Controller
  {
    [HttpGet]
    public ViewResult Index()
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
      Bm2s.Connectivity.Common.Article.Brand connect = new Bm2s.Connectivity.Common.Article.Brand();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

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
      Bm2s.Connectivity.Common.Article.Brand connect = new Bm2s.Connectivity.Common.Article.Brand();
      connect.Request.Brand = brand;
      connect.Delete();

      return connect.Request.Brand.Id;
    }
  }
}