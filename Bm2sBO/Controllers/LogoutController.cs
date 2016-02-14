using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2sBO.Models;

namespace Bm2sBO.Controllers
{
  public class LogoutController : Controller
  {
    [HttpPost]
    public bool Index(LoginModel model)
    {
      return model.CloseSession();
    }
  }
}