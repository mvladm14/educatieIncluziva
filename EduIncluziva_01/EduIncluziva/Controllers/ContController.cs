using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using EduIncluziva.Models;
using EduIncluziva.Metrics;
using System.Web.Helpers;
using System.Web.Mail;
using System.Net.Mail;

namespace EduIncluziva.Controllers
{
    public class ContController : Controller
    {
        //
        // GET: /Cont/

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(UserLogonModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (DataBaseValidator.ValidateUser(model.Mail, model.Parola))
                {
                    FormsAuthentication.SetAuthCookie(model.Mail, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Register Made by MMp
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmailDetail objEmailDetail)
        {
            try
            {

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("eduincluziva@gmail.com");
                mail.To.Add("mmp_mircea@yahoo.com");
                mail.Subject = "New User";

                string s = "";
                s += " Nume :  " + objEmailDetail.nume + "\n" +
                    " Prenume : " + objEmailDetail.prenume + "\n" +
                    "Mail : " + objEmailDetail.mail + "\n" +
                    "Descriere : " + objEmailDetail.bio + "\n" +
                    "Parola : " + objEmailDetail.pass;

                mail.Body = s;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("eduincluziva", "edu123456789");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                /* 
                 WebMail.SmtpServer = "smtp.gmail.com";
                 WebMail.UserName = "****@gmail.com";
                 WebMail.Password = "******";
                 WebMail.Send(objEmailDetail.ToEmail, objEmailDetail.Subject, objEmailDetail.Message, "dotnetpools@email.com");
                 ViewData["message"] = "Send Succesfully";*/
                return View("../../Views/Home/Index");
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.ToString();
            }
            return View("../../Views/Home/Index");

            /*
            ViewData["nume"] = nume;
            ViewData["prenume"] = prenume;
            ViewData["bio"] = bio;
            ViewData["mail"] = mail;

            EmailDetail ed = new EmailDetail(nume, prenume, bio, mail);
            bool ok = true;
            //ok = SendEmailValidate.SendEmail(ed);

            if (!ok)
            {
                RedirectToAction("Register", "Cont");
            }
            else
            {
                Redirect("http://www.google.ro");
            }

            return View();*/
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        /// <summary>
        /// Register for Elevi
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterElevi()
        {
            return View();
        }

        /// <summary>
        /// Register for Elevi de tip Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegisterElevi(ElevRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Student elev = new Student(model.Parola, model.Nume, model.Prenume, model.Mail);

                //User user = new User(model.Parola, model.Nume, model.Prenume, model.Mail);

                using (var db = new EducatieIncluzivaDBContext3())
                {                
                    //db.Useri.Add(user);
                    db.Students.Add(elev);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }                   

                    FormsAuthentication.SetAuthCookie(model.Nume, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ContulMeu(string mail)
        {
            ResourcesRepository rr = new ResourcesRepository();
            var model = rr.GetUserByMail(mail);

            return View(model);

        }
    }
}
