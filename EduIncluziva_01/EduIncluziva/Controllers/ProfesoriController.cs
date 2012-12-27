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
        [HttpPost]
        public ActionResult AdaugaLectii(FormCollection collection)
        {
            if (collection.AllKeys.Contains("materie1")) return View("AddStudents");
            if (collection.AllKeys.Contains("materie2")) return View("Profesori");
            if (collection.AllKeys.Contains("materie3")) return View("PaginaProfesorului");

            return View("Index");
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
