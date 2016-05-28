using Bm2s.Poco.Common.Partner;
using Bm2sBO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Partners.Controllers
{
    public class PartnerFamiliesController : Controller
    {
      [HttpPost]
      public int DeleteValue(PartnerFamily partnerFamily)
      {
        Bm2s.Connectivity.Common.Partner.PartnerFamily connect = new Bm2s.Connectivity.Common.Partner.PartnerFamily();
        connect.Request.PartnerFamily = partnerFamily;
        connect.Delete();

        return connect.Request.PartnerFamily.Id;
      }

      [HttpPost]
      public HtmlString GetValues()
      {
        Bm2s.Connectivity.Common.Partner.PartnerFamily connect = new Bm2s.Connectivity.Common.Partner.PartnerFamily();
        if (!UserUtils.CurrentUser.IsAdministrator)
        {
          connect.Request.Date = DateTime.Now;
        }

        connect.Get();

        return connect.Response.PartnerFamilies.ToHtmlJson();
      }

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
      public HtmlString SetValue(PartnerFamily partnerFamily)
      {
        Bm2s.Connectivity.Common.Partner.PartnerFamily connect = new Bm2s.Connectivity.Common.Partner.PartnerFamily();
        connect.Request.PartnerFamily = partnerFamily;
        connect.Post();

        SelectListUtils.ForceRefreshListFamily();

        return connect.Response.PartnerFamilies.FirstOrDefault().ToHtmlJson();
      }
    }
}