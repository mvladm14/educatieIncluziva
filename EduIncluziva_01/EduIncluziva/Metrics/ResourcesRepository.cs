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
        public void UpdateTeacher(string nume,   string prenume,
                                  string mail,   string bio,
                                  string c1, string c2, string c3)
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                // get the teacher
                var theUser = this.GetProfesoriByMail(mail);

                //update general info about the teacher
                theUser.Description = bio;
                theUser.Mail = mail;
                theUser.Nume = nume;
                theUser.Prenume = prenume;
                
                Course cur = new Course();
                cur.Nume = c1;
                Course cur2 = new Course();
                cur2.Nume = c2;
                Course cur3 = new Course();
                cur3.Nume = c3;

                cur.ProfesorId = theUser.UserId;
                cur2.ProfesorId = theUser.UserId;
                cur3.ProfesorId = theUser.UserId;

                //if the teacher already has some courses
                if (theUser.Materii != null)
                {
                    if (!theUser.Materii.Contains(cur))
                    {
                        context.Courses.Add(cur);
                    }
                    if (!theUser.Materii.Contains(cur2))
                    {
                        context.Courses.Add(cur2);
                    }
                    if (!theUser.Materii.Contains(cur3))
                    {
                        context.Courses.Add(cur3);
                    }
                }
                else
                {
                    context.Courses.Add(cur);
                    context.Courses.Add(cur2);
                    context.Courses.Add(cur3);
                }

                context.SaveChanges();

                context.Teachers.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;
                

            }
        }

        public void UpdateTeacher(string mail, string imageUrl)
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                var teacher = this.GetProfesoriByMail(mail);
                teacher.ImageUrl = imageUrl;
                context.Teachers.Attach(teacher);
                context.Entry(teacher).State = EntityState.Modified;
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