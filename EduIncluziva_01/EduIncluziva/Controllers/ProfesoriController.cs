﻿using System;
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
        public ActionResult Update(Teacher te)
        {
            using (var db = new EducatieIncluzivaDbContext())
            {
                Teacher t = db.Teachers.FirstOrDefault(p => p.Mail.Equals(te.Mail));
                if (t != null)
                {
                    t.Materii = te.Materii;
                    t.Nume = te.Nume;
                    t.Prenume = te.Prenume;
                    t.Description = te.Description;
                    DbEntityEntry<Teacher> entry = db.Entry(t);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                }
               

            }
            return RedirectToAction("Index", "Home");
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
