using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EduIncluziva.Models;

namespace EduIncluziva.Metrics
{
    public class ResourcesRepository
    {
        #region Profesori
        /// <summary>
        /// Returns a Profesor corresponding to the Profesor_Mail parameter.
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public Teacher GetProfesoriByMail(string mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.Teachers.SingleOrDefault(item => item.Mail == mail);
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }
        public void UpdateTeacher(string nume, string prenume, string mail, string bio, string imgurl, string c1, string c2, string c3)
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                List<Course> curs = new List<Course>();
                Course cur = new Course();
                cur.Nume = c1;
                Course cur2 = new Course();
                cur2.Nume = c2;
                Course cur3 = new Course();
                cur3.Nume = c3;
                curs.Add(cur);
                curs.Add(cur2);
                curs.Add(cur3);


                var theUser = this.GetProfesoriByMail(mail);
                theUser.Description = bio;
                theUser.Mail = mail;
                theUser.ImageUrlSetter = imgurl;
                theUser.Nume = nume;
                theUser.Prenume = prenume;
                theUser.Materii = curs;
                context.Teachers.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
        /// <summary>
        /// Returns a Profesor corresponding to the GUID parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher GetProfesorById(Guid id)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.Teachers.SingleOrDefault(item => item.UserId.Equals(id));
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
        /// <param name="mail"></param>
        /// <returns></returns>
        public User GetUserByMail(string mail)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.Users.SingleOrDefault(item => item.Mail == mail);
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
            using (var context = new EducatieIncluzivaDbContext())
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

        public HighSchool GetHighSchoolByName(string name)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.HighSchools.Include("Users")
                                              .SingleOrDefault(item => item.Nume == name);
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
                using (var context = new EducatieIncluzivaDbContext())
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

        public HighSchool GetHighSchoolById(Guid highSchoolId)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.HighSchools.Include("Users").SingleOrDefault(
                        highschool => highschool.HighSchoolId == highSchoolId);
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