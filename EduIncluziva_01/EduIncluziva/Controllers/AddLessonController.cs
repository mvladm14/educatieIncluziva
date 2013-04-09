using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace EduIncluziva.Controllers
{
    public class AddLessonController : Controller
    {
        //
        // GET: /AddLesson/
        public ActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLesson(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
