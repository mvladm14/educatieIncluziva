using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduIncluziva.Models;

namespace EduIncluziva.Metrics
{
    public class ResourcesRepository
    {
        #region Profesori
        /// <summary>
        /// Returns a Profesor corresponding to the Profesor_Mail parameter.
        /// </summary>
        /// <param name="Mail"></param>
        /// <returns></returns>
        public Teacher GetProfesoriByMail(string Mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext4())
                {
                    return context.Teachers.SingleOrDefault(item => item.Mail == Mail);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }

        /// <summary>
        /// Returns a Profesor corresponding to the GUID parameter.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Teacher GetProfesorByID(Guid ID)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext4())
                {
                    return context.Teachers.SingleOrDefault(item => item.User_ID.Equals(ID));
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
                using (var context = new EducatieIncluzivaDBContext4())
                {
                    return context.Users.SingleOrDefault(item => item.Mail == Mail);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw exc;
            }
        }

        #endregion
    }
}