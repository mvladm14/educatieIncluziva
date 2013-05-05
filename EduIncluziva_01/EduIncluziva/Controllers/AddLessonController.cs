using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EduIncluziva.Models;
using System.Data.Entity.Infrastructure;
using System.Data;
using EduIncluziva.Metrics;

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
                ViewData["fileUp"] = null;
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var subPath = "~/App_Data/uploads/" + mail;

                bool IsExists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!IsExists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                }

                var subPath2 = "~/App_Data/uploads/" + mail + "/" + materie;

                bool IsExists2 = System.IO.Directory.Exists(Server.MapPath(subPath2));

                if (!IsExists2)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath2));
                }

                var path = Path.Combine(Server.MapPath("~/App_Data/uploads/"),  mail + "/" , materie, fileName);
                file.SaveAs(path);

                using (var db = new EducatieIncluzivaDbContext())
                {
                    Teacher myTeacher = db.Teachers.FirstOrDefault(p => p.Mail.Equals(mail));
                    myTeacher.ImageUrl = path.ToString();

                    DbEntityEntry<Teacher> entry = db.Entry(myTeacher);
                    entry.State = EntityState.Modified;

                    db.SaveChanges();
                    ViewData["fileUp"] = "incarcat";
                    ViewData["materie"] = materie;
                }
            }
            var rr = new ResourcesRepository();

            var model = rr.GetUserByMail(mail);
           
            // redirect back to the index action to show the form once again
            return View("../../Views/AddLesson/AddLesson", model);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
