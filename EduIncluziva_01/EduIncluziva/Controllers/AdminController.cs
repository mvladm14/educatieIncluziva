using System.Web.Routing;
using EduIncluziva.Metrics;
using EduIncluziva.Models;
using System.Web.Mvc;
using System.Data;
using System;
using System.Web.Security;
using System.Collections.Generic;

namespace EduIncluziva.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminPage(SearchedUserModel uim)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CautaUtilizator", "Admin", new { mail = uim.Mail });
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdaugaUtilizatorNou()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdaugaUtilizatorNou(TeacherRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ResourcesRepository rr = new ResourcesRepository();
                HighSchool hs = rr.GetHighSchoolByName(model.ScoalaDeProvenienta);

                Teacher teacher = new Teacher(model.Parola, model.Nume, model.Prenume, model.Mail, hs);

                //User user = new User(model.Parola, model.Nume, model.Prenume, model.Mail);

                using (var db = new EducatieIncluzivaDBContext())
                {
                    //db.Useri.Add(user);
                    db.Entry(hs).State = EntityState.Unchanged;
                    db.Teachers.Add(teacher);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    //FormsAuthentication.SetAuthCookie(model.Mail, false /* createPersistentCookie */);
                    //return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }



        public ActionResult CautaUtilizator(string mail)
        {
            if (ModelState.IsValid)
            {
                ResourcesRepository rr = new ResourcesRepository();
                User user = rr.GetUserByMail(mail);
                UserInfoModel newUim = new UserInfoModel();
                newUim.Nume = user.Nume;
                newUim.Prenume = user.Prenume;
                newUim.Mail = user.Mail;
                newUim.Parola = user.Parola;
                //TODO change the schoolName
                newUim.ScoalaDeProvenienta = "Liceu1";
                return View(newUim);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CautaUtilizator(UserInfoModel userInfoModel)
        {
            if (ModelState.IsValid)
            {
                ResourcesRepository rr = new ResourcesRepository();
                HighSchool highSchool = rr.GetHighSchoolByName("Liceu1");
                rr.UpdateUser(userInfoModel.Parola, userInfoModel.Nume, userInfoModel.Prenume, userInfoModel.Mail, highSchool);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult InformatiiLicee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InformatiiLicee(SearchedHighSchoolModel searchedHighSchoolModel)
        {
            if (ModelState.IsValid)
            {
                //var rr = new ResourcesRepository();
                //var highSchool = rr.GetHighSchoolByName(searchedHighSchoolModel.Nume);
                return RedirectToAction("CautaLiceu", "Admin", new { searchedHighSchoolName = searchedHighSchoolModel.Nume });
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CautaLiceu(string searchedHighSchoolName)
        {
            var rr = new ResourcesRepository();
            var model = rr.GetHighSchoolByName(searchedHighSchoolName);
            return View(model);
        }

        public ActionResult CereriInregistrare()
        {
            List<InregistrareProfesorModel> requests;
            var rr = new ResourcesRepository();
            requests = rr.GetAllRegistrationRequests();

            return View(requests);
        }

        public ActionResult Approve(Guid id)
        {
            var rr = new ResourcesRepository();

            var request = rr.GetRequestById(id);

            var highschool = rr.GetHighSchoolByName(request.ScoalaDeProveninenta);

            var teacher = new Teacher(request.Parola, request.Nume, request.Prenume,
                                      request.Mail, highschool);
            using (var context = new EducatieIncluzivaDBContext())
            {
                var entry = context.RegistrationRequests.Find(id);
                context.RegistrationRequests.Remove(entry);
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
            return RedirectToAction("CereriInregistrare");
        }

        public ActionResult Reject(Guid id)
        {
            using (var context = new EducatieIncluzivaDBContext())
            {
                var entry = context.RegistrationRequests.Find(id);
                context.RegistrationRequests.Remove(entry);
                context.SaveChanges();
            }
            return RedirectToAction("CereriInregistrare");
        }

    }
}
