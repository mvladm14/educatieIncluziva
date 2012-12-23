using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduIncluziva.Controllers
{
    public class LessonController : Controller
    {
        //
        // GET: /Lesson/

        public ActionResult AddLesson()
        {
            return View();
        }

       
        public ActionResult Index()
        {
            return View();
        }

    }
}
