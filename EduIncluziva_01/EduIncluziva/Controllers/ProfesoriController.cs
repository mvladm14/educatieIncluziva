using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduIncluziva.Controllers
{
    public class ProfesoriController : Controller
    {

        public ActionResult PaginaProfesorului()
        {
            return View();
        }

        public ActionResult AddStudents()
        {
            return View();
        }
        //
        // GET: /Profesori/
        public ActionResult Profesori()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
