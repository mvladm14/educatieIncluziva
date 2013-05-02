using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EduIncluziva.Models;
using System.Data.Entity.Infrastructure;
using System.Data;

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
        public ActionResult AddLesson(HttpPostedFileBase file,string mail, string materie)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/" + mail + "/" + materie), fileName);
                file.SaveAs(path);

                using (var db = new EducatieIncluzivaDbContext())
                {
                    Teacher myTeacher = db.Teachers.FirstOrDefault(p => p.Mail.Equals(mail));
                    myTeacher.ImageUrl = path.ToString();
                    DbEntityEntry<Teacher> entry = db.Entry(myTeacher);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
 
                }
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
