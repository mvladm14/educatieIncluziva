﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EduIncluziva.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        
    }
}
