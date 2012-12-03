using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduIncluziva.Models;

namespace EduIncluziva.Controllers
{
    public class EleviController : Controller
    {
        //
        // GET: /Elevi/

        EducatieIncluzivaDBContext _educatieIncluzivaDB = new EducatieIncluzivaDBContext();


        public ActionResult Index()
        {
            var model = _educatieIncluzivaDB.Elevis;

            return View(model);
        }

    }
}
