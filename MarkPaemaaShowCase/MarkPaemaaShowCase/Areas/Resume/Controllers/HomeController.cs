﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkPaemaaShowCase.Areas.Resume.Controllers
{
    public class HomeController : Controller
    {
        // GET: Resume/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}