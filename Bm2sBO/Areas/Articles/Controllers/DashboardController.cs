﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bm2sBO.Areas.Articles.Controllers
{
  public class DashboardController : Controller
  {
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }
  }
}