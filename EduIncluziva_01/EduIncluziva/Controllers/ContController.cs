﻿using System;
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
        public ActionResult LogOn(ElevLogonModel model, string returnUrl)
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
        public ActionResult Register(string nume,string prenume, string bio, string mail)
        {
            ViewData["nume"] = nume;
            ViewData["prenume"] = prenume;
            ViewData["bio"] = bio;
            ViewData["mail"] = mail;

            EmailDetail ed = new EmailDetail(nume, prenume, bio, mail);
            bool ok = true;
            ok = SendEmailValidate.SendEmail(ed);

            if (!ok)
            {
                RedirectToAction("Register", "Cont");
            }
            else
            {
                Redirect("http://www.google.ro");
            }

            return View();
        }
        public ActionResult SendEmail()
        {
            return View();
        }

       
        
       
    }
}
