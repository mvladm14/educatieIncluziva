using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduIncluziva.Metrics;
using EduIncluziva.Models;

namespace EduIncluziva.Controllers
{
    public class ProfesoriController : Controller
    {

        public ActionResult PaginaProfesorului(string mail)
        {
            var rr = new ResourcesRepository();
            var user = rr.GetUserByMail(mail);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(FormCollection te, string mail)
        {
            var rr = new ResourcesRepository();
            var model = rr.GetUserByMail(mail);
            if (te.GetValue("teach.Materii[0]").AttemptedValue.Equals("") ||
                te.GetValue("teach.Nume").AttemptedValue.Equals("") ||
                te.GetValue("teach.Prenume").AttemptedValue.Equals("") ||
                te.GetValue("teach.Description").AttemptedValue.Equals(""))
            {
                TempData["alertMessage"] = "The user has to be alerted";
                return View("../../Views/Cont/ContulMeu", model);
              
            }
            else
            {
                TempData["alertMessage"] = null;
                string numeCurs1 = te.GetValue("teach.Materii[0]").AttemptedValue;
                string numeCurs2 = te.GetValue("teach.Materii[1]").AttemptedValue;
                string numeCurs3 = te.GetValue("teach.Materii[2]").AttemptedValue;

                string nume = te.GetValue("teach.Nume").AttemptedValue;
                string prenume = te.GetValue("teach.Prenume").AttemptedValue;
                string description = te.GetValue("teach.Description").AttemptedValue;

                    int index = 0;
                    string c1,c2,c3;
                    c1 = "";
                    c2 = "";
                    c3 = "";

                    using (var db = new EducatieIncluzivaDbContext())
                    {
                        var curs = from p in db.Courses
                                   where p.ProfesorId == model.UserId
                                   select p;

                        foreach (var c in curs)
                        {
                            if (index == 0)
                            {
                                c1 = c.Nume;
                            }
                            else if (index == 1)
                            {
                                c2 = c.Nume;

                            }
                            else if (index == 2)
                            {
                                c3 = c.Nume;
                            }
                            index++;
                        }
                    }  

                if (numeCurs2.Equals(""))
                {
                    rr.UpdateTeacher(nume, prenume, mail, description,
                                 numeCurs1, c1);
                }
                else if (numeCurs3.Equals(""))
                {
                    rr.UpdateTeacher(nume, prenume, mail, description,
                                 numeCurs1, numeCurs2,c1, c2);
                }
                else
                {
                    rr.UpdateTeacher(nume, prenume, mail, description,
                                     numeCurs1, numeCurs2, numeCurs3,c1,c2, c3);
                }
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult AdaugaLectii(FormCollection collection)
        {
            ViewData["materie"] = "";
            if (collection.AllKeys.Contains("materie1"))
            {
                ViewData["materie"] = "materie1";
                return View("../../Views/AddLesson/AddLesson");
            }
            if (collection.AllKeys.Contains("materie2"))
            {
                ViewData["materie"] = "materie2";
                return View("../../Views/AddLesson/AddLesson");

            }
            if (collection.AllKeys.Contains("materie3"))
            {
                ViewData["materie"] = "materie3";
                return View("../../Views/AddLesson/AddLesson");
            }
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

        public ActionResult SubmitToLesson(string materie,string mail)
        {
           /* if (materie.Equals("0"))
            {
                ViewData["materie"] = "materie0";
            }
            else if (materie.Equals("1"))
            {
                ViewData["materie"] = "materie1";
            }
            else if (materie.Equals("2"))
            {
                ViewData["materie"] = "materie2";
            }*/
            ViewData["materie"] = materie;
            var rr = new ResourcesRepository();
          
            var model = rr.GetUserByMail(mail);
           
            return View("../../Views/AddLesson/AddLesson",model);

        }

        [HttpPost]
        public ActionResult AdaugaPoza(HttpPostedFileBase file, string mail)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                //store the file in a new created folder
                //the new created folder bears the name of the logged in user = teacher
                var directoryPath = Server.MapPath("~/Content/Pictures/Profesori/" + mail);
                Directory.CreateDirectory(directoryPath);
                var path = Path.Combine(Server.MapPath("~/Content/Pictures/Profesori/" + mail), fileName);
                file.SaveAs(path);


                //update the user so that he now stores the picture
                string imageUrl = "~/Content/Pictures/Profesori/" + mail + "/" + fileName;

                var rr = new ResourcesRepository();
                rr.UpdateTeacher(mail, imageUrl);
                var user = rr.GetUserByMail(mail);


            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index", "Home");
        }

    }
}
