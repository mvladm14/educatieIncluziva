using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduIncluziva.Models;
using System.Net.Mail;

namespace EduIncluziva.Metrics
{
    public class ResourcesRepository
    {
        #region Elev
        /// <summary>
        /// Returns an Elev corresponding to the Elev_Mail parameter.
        /// </summary>
        /// <param name="Mail"></param>
        /// <returns></returns>
        public Elevi GetEleviByMail(string Mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext())
                {
                    return context.Elevis.SingleOrDefault(item => item.Mail == Mail);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }

        #endregion



        #region Profesori
        /// <summary>
        /// Returns a Profesor corresponding to the Profesor_Mail parameter.
        /// </summary>
        /// <param name="Mail"></param>
        /// <returns></returns>
        public Profesori GetProfesoriByMail(string Mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext())
                {
                    return context.Profesoris.SingleOrDefault(item => item.Mail == Mail);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }
        #endregion


    }

    public static class SendEmailValidate
    {
        public static bool SendEmail(EmailDetail objEmailDetail)
        {
            try
            {
                int port = 587;
                string userName = "incluzivs@gmail.com";
                string password = "IonCreanga";


                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new MailAddress(objEmailDetail.mail);
                message.To.Add(new MailAddress("mmp_mircea@yahoo.com"));
                message.Subject = "Utilizator Nou";
                message.Body = " teste";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", port);
                smtp.Credentials = new System.Net.NetworkCredential(userName, password);
                smtp.EnableSsl = true;

                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            catch
            {
              //  ViewData["message"] = ex.ToString();
                return false;
            }
            return true;
        }
    }
}