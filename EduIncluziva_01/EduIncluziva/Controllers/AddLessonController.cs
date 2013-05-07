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
        public ActionResult DeleteLesson(string mail, string materie, string name)
        {
            ViewBag.stergere = null;
            ViewData["materie"] = materie;
            var rr = new ResourcesRepository();
            var model = rr.GetProfesoriByMail(mail);
            if (rr.EraseLesson(name, mail, materie) == 1)
            {
                ViewBag.eraseData = "Lectia a fost stearsa cu succes";
                ViewBag.stergere = 1;
           
            }
            else
            {
                ViewBag.eraseData = "Lectia cu numele " + name + " nu a putut fi stearsa. Verificati cu atentie numele lectiei";
                ViewBag.stergere = 0;
           
            }

            return View("../../Views/AddLesson/AddLesson", model);
        }
        
        [HttpPost]
        public ActionResult SearchForLesson(string mail, string materie,string name)
        {
            ViewBag.myData = null;
            ViewBag.nr = null;
            ViewData["materie"] = materie;
            var rr = new ResourcesRepository();
            var model = rr.GetProfesoriByMail(mail);

            if (rr.FindLesson(name, mail, materie) == 1)
            {
                ViewBag.myData = "Lectia se afla in baza de date";
                ViewBag.nr = 1;
            }
            else
            {
                ViewBag.myData = "Lectia cu numele " + name + " nu se gaseste momentan in baza de date.";
                ViewBag.nr = 0;
            }

             return View("../../Views/AddLesson/AddLesson", model);
        }
        [HttpPost]
        public ActionResult ViewLesson(string mail,FormCollection c)
        {
            var rr = new ResourcesRepository();
            var model = rr.GetProfesoriByMail(mail);
            string link = "http://www.google.com";
            return Redirect(link);
            //return View("../../Views/AddLesson/AddLesson", model);
  
        }
        [HttpPost]
        public ActionResult AddLesson(HttpPostedFileBase file,string mail, string materie)
        {
            var rr = new ResourcesRepository();

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
                    var myTeacher = db.Teachers.SingleOrDefault(item => item.Mail == mail);
                    var curs = from p in db.Courses
                               where p.Nume.Equals(materie) && p.ProfesorId == myTeacher.UserId
                               select p;  

                  /*  Course cur = new Course();
                    cur.Nume = materie;
                    cur.ProfesorId = myTeacher.UserId;
                    */
                    Lesson l = new Lesson();
                    l.ProfesorOwner = myTeacher;
                    l.ProfesorOwnerId = myTeacher.UserId;
                    l.Titlu = fileName;

                    foreach (var c in curs)
                    {
                        c.Lectii.Add(l);
                        break;
                    } 
                  /*  if (myTeacher.Materii != null)
                    {
                        if (myTeacher.Materii.Contains(cur))
                        {
                            db.Lessons.Add(l);
                        }
                        else
                        {
                            Console.WriteLine("Nu exista");
                        }
                    }
                    else
                    {
                        Console.WriteLine("e NULL");
                    }
                    /*
                    if (myTeacher.Materii[0].Nume.Equals(materie))
                    {
                        nr = 0;
                    }
                    else if (myTeacher.Materii[1].Nume.Equals(materie))
                    {
                        nr = 1;
                    }
                    else
                    {
                        nr = 2;
                    }
                    myTeacher.Materii[nr].Lectii.Add(l);
                    */
                    DbEntityEntry<Teacher> entry = db.Entry(myTeacher);
                    entry.State = EntityState.Modified;

                    db.SaveChanges();

                    ViewData["fileUp"] = "incarcat";
                    ViewData["materie"] = materie;
                }
            }
           
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
