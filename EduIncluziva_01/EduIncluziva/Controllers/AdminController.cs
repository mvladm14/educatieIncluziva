using EduIncluziva.Metrics;
using EduIncluziva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduIncluziva.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult AdaugaUtilizatorNou()
        {
            return View();
        }

        public ActionResult CautaUtilizator()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CautaUtilizator(UserInfoModel uim)
        {
            if (ModelState.IsValid)
            {
                ResourcesRepository rr = new ResourcesRepository();
                User user = rr.GetUserByMail(uim.Mail);
                UserInfoModel newUIM = new UserInfoModel();
                    newUIM.Nume = user.Nume;
                    newUIM.Prenume = user.Prenume;
                    newUIM.Mail = user.Mail;
                    newUIM.Parola = user.Parola;
                    newUIM.ScoalaDeProvenienta = user.ScoalaDeProvenienta;
                    return View(newUIM);
            }
            return View(uim);
        }

    }
}
