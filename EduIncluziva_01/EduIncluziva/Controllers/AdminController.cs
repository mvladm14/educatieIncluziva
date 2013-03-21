using EduIncluziva.Metrics;
using EduIncluziva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}
