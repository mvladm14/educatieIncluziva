using System;
using System.Collections.Generic;
using System.Data;
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
                using (var context = new EducatieIncluzivaDBContext9())
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
                using (var context = new EducatieIncluzivaDBContext9())
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
                using (var context = new EducatieIncluzivaDBContext9())
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

        public void UpdateUser(string parola, string nume, string prenume, string mail,
                               HighSchool scoalaDeProvenienta)
        {
            using (var context = new EducatieIncluzivaDBContext9())
            {
                var theUser = this.GetUserByMail(mail);
                theUser.Parola = parola == null ? theUser.Parola : parola;
                theUser.Nume = nume == null ? theUser.Nume : nume;
                theUser.Prenume = prenume == null ? theUser.Prenume : prenume;
                theUser.Mail = mail == null ? theUser.Mail : mail;
                theUser.ScoalaDeProvenienta = (scoalaDeProvenienta == theUser.ScoalaDeProvenienta) ? theUser.ScoalaDeProvenienta : scoalaDeProvenienta;

                context.Users.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        #endregion

        #region HighSchool

        public HighSchool GetHighSchoolByName(string Name)
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext9())
                {
                    return context.HighSchools.SingleOrDefault(item => item.Nume == Name);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw exc;
            }
        }

        public List<HighSchool> GetAllHighSchools()
        {
            try
            {
                using (var context = new EducatieIncluzivaDBContext9())
                {
                    return context.HighSchools.ToList();
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