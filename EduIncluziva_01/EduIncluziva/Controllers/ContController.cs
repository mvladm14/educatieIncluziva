using System;
using System.Web.Mvc;
using System.Web.Security;
using EduIncluziva.Models;
using EduIncluziva.Metrics;
using System.Net.Mail;
using System.Data;

namespace EduIncluziva.Controllers
{
    public class ContController : Controller
    {
        //
        // GET: /Cont/

        #region Autentificare

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
                    ModelState.AddModelError("", "Username-ul sau parola sunt gresite.");
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

        #endregion


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
                s += " Nume :  " + objEmailDetail.Nume + "\n" +
                    " Prenume : " + objEmailDetail.Prenume + "\n" +
                    "Mail : " + objEmailDetail.Mail + "\n" +
                    "Descriere : " + objEmailDetail.Bio + "\n" +
                    "Parola : " + objEmailDetail.Pass;

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

        #region InregistrareElev

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
                ResourcesRepository rr = new ResourcesRepository();
                HighSchool hs = rr.GetHighSchoolByName(model.ScoalaDeProvenienta);

                Student elev = new Student(model.Parola, model.Nume, model.Prenume, model.Mail, hs);

                //User user = new User(model.Parola, model.Nume, model.Prenume, model.Mail);

                using (var db = new EducatieIncluzivaDbContext())
                {                
                    //db.Useri.Add(user);
                    db.Entry(hs).State = EntityState.Unchanged;
                    db.Students.Add(elev);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }                   

                    FormsAuthentication.SetAuthCookie(model.Mail, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        public ActionResult ContulMeu(string mail)
        {
            ResourcesRepository rr = new ResourcesRepository();
            var model = rr.GetUserByMail(mail);

            return View(model);

        }
    }
}
