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

                context.Teachers.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;
                
                context.SaveChanges();


            }
        }
        public void UpdateTeacher(string nume, string prenume,
                                  string mail, string bio,
                                  string c1)
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
                cur.ProfesorId = theUser.UserId;
               
                //if the teacher already has some courses
                if (theUser.Materii != null)
                {
                    if (!theUser.Materii.Contains(cur))
                    {
                        context.Courses.Add(cur);
                    }
                }
                else
                {
                    context.Courses.Add(cur);
                }


                context.Teachers.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;

                context.SaveChanges();


            }
        }
        public void UpdateTeacher(string nume, string prenume,
                                  string mail, string bio,
                                  string c1, string c2)
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
                
                cur.ProfesorId = theUser.UserId;
                cur2.ProfesorId = theUser.UserId;
                
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
                 }
                else
                {
                    context.Courses.Add(cur);
                    context.Courses.Add(cur2);
                   
                 }

                context.Teachers.Attach(theUser);
                context.Entry(theUser).State = EntityState.Modified;
                context.SaveChanges();

              
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
        public int FindLesson(string name, string mail,string materii)
        {
            int nr=0;
          /*  var rr = new ResourcesRepository();
            var model = rr.GetProfesoriByMail(mail);
            if(materii.Equals(model.Materii[0].Nume))
                nr = 0;
            else if(materii.Equals(model.Materii[1].Nume))
                nr = 1;
            else
            {
                nr = 2;
            }
            foreach (Lesson l in model.Materii[nr].Lectii)
            {
                if (l.Titlu.Equals(name))
                    return 1;
            }*/
            return 0;
        }

        public int EraseLesson(string nume,string mail,string materii)
        {
            try
            {

                int nr = 0;
                var rr = new ResourcesRepository();
                var model = rr.GetProfesoriByMail(mail);
                if (materii.Equals(model.Materii[0].Nume))
                    nr = 0;
                else if (materii.Equals(model.Materii[1].Nume))
                    nr = 1;
                else
                {
                    nr = 2;
                }
                int index = 0;
                foreach (Lesson l in model.Materii[nr].Lectii)
                {
                    index++;
                    if (l.Titlu.Equals(nume))
                    {
                        break;
                    }
                }
                model.Materii[nr].Lectii.RemoveAt(index);

                using (var context = new EducatieIncluzivaDbContext())
                {
                    context.Teachers.Attach(model);
                    context.Entry(model).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return 1;
            }
            catch 
            {
                return 0;
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