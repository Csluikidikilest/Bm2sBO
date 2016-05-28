using Bm2s.Poco.Common.Partner;
using Bm2sBO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Partners.Controllers
{
  public class PartnersController : Controller
  {
    [HttpPost]
    public HtmlString GetPartnerContacts(int partnerId)
    {
      Bm2s.Connectivity.Common.Partner.PartnerContact connect = new Bm2s.Connectivity.Common.Partner.PartnerContact();
      connect.Request.PartnerId = partnerId;
      connect.Get();

      return connect.Response.PartnerContacts.ToHtmlJson();
    }

    [HttpPost]
    public HtmlString GetPartnerPartnerFamilies(int partnerId)
    {
      Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily connect = new Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily();
      connect.Request.PartnerId = partnerId;
      connect.Get();

      return connect.Response.PartnerPartnerFamilies.Select(partnerPartnerFamily => partnerPartnerFamily.PartnerFamily.Id).ToHtmlJson();
    }

    [HttpPost]
    public HtmlString GetValues()
    {
      Bm2s.Connectivity.Common.Partner.Partner connect = new Bm2s.Connectivity.Common.Partner.Partner();
      if (!UserUtils.CurrentUser.IsAdministrator)
      {
        connect.Request.Date = DateTime.Now;
      }

      connect.Get();

      return connect.Response.Partners.ToHtmlJson();
    }

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
    public HtmlString SetValue(Partner partner, List<PartnerContact> contacts, List<int> partnerPartnerFamiliesId)
    {
      Bm2s.Connectivity.Common.Partner.Partner connect = new Bm2s.Connectivity.Common.Partner.Partner();
      connect.Request.Partner = partner;
      connect.Post();

      if (contacts == null)
      {
        contacts = new List<PartnerContact>();
      }

      Bm2s.Connectivity.Common.Partner.PartnerContact connectContact = new Bm2s.Connectivity.Common.Partner.PartnerContact();
      foreach (PartnerContact contact in contacts)
      {
        contact.Partner = connect.Response.Partners.FirstOrDefault();
        connectContact.Request.PartnerContact = contact;
        connectContact.Post();
      }

      if (partnerPartnerFamiliesId == null)
      {
        partnerPartnerFamiliesId = new List<int>();
      }

      Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily connectPartnerFamily = new Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily();
      connectPartnerFamily.Request.PartnerId = connect.Response.Partners.FirstOrDefault().Id;
      connectPartnerFamily.Get();

      Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily removePartnerPartnerFamily;
      foreach (PartnerPartnerFamily partnerPartnerFamily in connectPartnerFamily.Response.PartnerPartnerFamilies.Where(item => !partnerPartnerFamiliesId.Contains(item.PartnerFamily.Id)))
      {
        removePartnerPartnerFamily = new Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily();
        removePartnerPartnerFamily.Request.PartnerPartnerFamily = partnerPartnerFamily;
        removePartnerPartnerFamily.Delete();
      }

      Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily addPartnerPartnerFamily;
      foreach (int partnerFamilyId in partnerPartnerFamiliesId.Where(item => !connectPartnerFamily.Response.PartnerPartnerFamilies.Any(papf => papf.PartnerFamily.Id == item)))
      {
        addPartnerPartnerFamily = new Bm2s.Connectivity.Common.Partner.PartnerPartnerFamily();
        addPartnerPartnerFamily.Request.PartnerPartnerFamily = new PartnerPartnerFamily();
        addPartnerPartnerFamily.Request.PartnerPartnerFamily.Partner = connect.Response.Partners.FirstOrDefault();
        addPartnerPartnerFamily.Request.PartnerPartnerFamily.PartnerFamily = new PartnerFamily();
        addPartnerPartnerFamily.Request.PartnerPartnerFamily.PartnerFamily.Id = partnerFamilyId;
        addPartnerPartnerFamily.Post();
      }

      return connect.Response.Partners.FirstOrDefault().ToHtmlJson();
    }
  }
}