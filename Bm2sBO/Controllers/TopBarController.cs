﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bm2sBO.Models;

namespace Bm2sBO.Controllers
{
    public class TopBarController : Controller
    {
        public ActionResult Index()
        {
            return PartialView(new TopBarModel());
        }
    }
}