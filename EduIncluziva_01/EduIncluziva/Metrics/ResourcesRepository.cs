using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduIncluziva.Models;

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

        #region User
        /// <summary>
        /// Returns an User corresponding to the Mail parameter.
        /// </summary>
        /// <param name="Mail"></param>
        /// <returns></returns>
        public User GetUserByMail(string Mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext())
                {
                    return context.Users.SingleOrDefault(item => item.Mail == Mail);
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
}