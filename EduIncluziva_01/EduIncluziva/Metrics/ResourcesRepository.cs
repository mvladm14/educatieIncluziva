using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EduIncluziva.Models;

namespace EduIncluziva.Metrics
{
    public class ResourcesRepository
    {

        #region Courses

        public List<Course> GetCoursesByTeacherMail(string mail)
        {
            var courses = new List<Course>();
            var user = this.GetProfesoriByMail(mail);
            var userId = user.UserId;

            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    courses = context.Courses
                               .Where(c => c.ProfesorId == userId)
                               .OrderBy(c => c.Nume)
                               .ToList<Course>();
                }
            }
            catch
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
            return courses;
        }

        public Course GetCourseById(Guid courseId)
        {
            try
            {
                using (var context = new EducatieIncluzivaDbContext())
                {
                    return context.Courses.SingleOrDefault(item => item.CourseId.Equals(courseId));
                }
            }
            catch
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }

        #endregion

        #region Lessons

        public List<Lesson> GetAllLessons(string mail, string materie)
        {
            List<Lesson> myList = new List<Lesson>();
            try
            {
                using (var db = new EducatieIncluzivaDbContext())
                {
                    var rr = new EduIncluziva.Metrics.ResourcesRepository();
                    var teach = rr.GetProfesoriByMail(mail);
                    var curs = (from p in db.Courses
                                where p.Nume.Equals(materie) && p.ProfesorId == teach.UserId
                                select p).FirstOrDefault();
                    var lectii = from p in db.Lessons
                                 where p.ProfesorOwner == teach
                                 select p;
                    var b = db.Lessons.ToList();

                    foreach (Lesson c in b)
                    {
                        if (c.ProfesorOwnerId == teach.UserId && c.CourseId == curs.CourseId)
                            myList.Add(c);
                    }
                    return myList;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public int GetCursNumber(string materie, string mail)
        {
            int index = 0;
            using (var db = new EducatieIncluzivaDbContext())
            {
                var rr = new EduIncluziva.Metrics.ResourcesRepository();
                var teach = rr.GetProfesoriByMail(mail);
                var curs = from p in db.Courses
                           where p.ProfesorId == teach.UserId
                           select p;
                foreach (var c in curs)
                {
                    if (c.Nume.Equals(materie))
                        break;
                    else
                        index++;
                }
            }
            return index;
        }
        #endregion

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
            catch
            {
                //Logger.Instance.LogError(ErrorCategory.Data, "Unable to retrieve information about Employees.", exc);
                throw new InvalidUserException();
            }
        }
        private void UpdateCurs(string cursNume, Teacher t1, string numevechi1)
        {
            using (var context = new EducatieIncluzivaDbContext())
            {
                Course curs = (from p in context.Courses
                               where p.ProfesorId == t1.UserId && p.Nume.Equals(numevechi1)
                               select p).FirstOrDefault();

                if (curs != null)
                {
                    curs.Nume = cursNume;
                    DbEntityEntry<Course> entry = context.Entry(curs);
                    entry.State = EntityState.Modified;
                    context.SaveChanges();

                }
                else
                {
                    Course cur = new Course();
                    cur.Nume = cursNume;
                    cur.ProfesorId = t1.UserId;
                    context.Courses.Add(cur);
                    context.SaveChanges();
                }
            }
        }
        public void UpdateTeacher(string nume, string prenume,
                                  string mail, string bio,
                                   string numevechi1, string numevechi2, string numevechi3, string c2, string c1, string c3)
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

                UpdateCurs(c1, theUser, numevechi1);
                UpdateCurs(c2, theUser, numevechi2);
                UpdateCurs(c3, theUser, numevechi3);

                DbEntityEntry<Teacher> entry = context.Entry(theUser);
                entry.State = EntityState.Modified;
                context.SaveChanges();


            }
        }
        public void UpdateTeacher(string nume, string prenume,
                                  string mail, string bio,
                                   string numevechi1, string c1)
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

                /*    Course cur = new Course();
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

                    */
                UpdateCurs(c1, theUser, numevechi1);

                DbEntityEntry<Teacher> entry = context.Entry(theUser);
                entry.State = EntityState.Modified;
                context.SaveChanges();



            }
        }
        public void UpdateTeacher(string nume, string prenume,
                                  string mail, string bio,
                                 string numevechi1, string numevechi2,  string c1, string c2)
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


                /* Course cur = new Course();
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
                 */
                UpdateCurs(c1, theUser, numevechi1);
                UpdateCurs(c2, theUser, numevechi2);

                DbEntityEntry<Teacher> entry = context.Entry(theUser);
                entry.State = EntityState.Modified;
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
            catch
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
        public int FindLesson(string name, string mail, string materii)
        {
            var rr = new ResourcesRepository();
            var model = rr.GetProfesoriByMail(mail);

            using (var context = new EducatieIncluzivaDbContext())
            {
                Course curs = (from p in context.Courses
                               where p.ProfesorId == model.UserId && p.Nume.Equals(materii)
                               select p).FirstOrDefault();

                Lesson l = (from m in context.Lessons
                            where m.CourseId == curs.CourseId && m.ProfesorOwnerId == model.UserId && m.Titlu.Equals(name)
                            select m).FirstOrDefault();
                if (l != null)
                {
                    return 1;
                }

            }

            return 0;
        }

        public int EraseLesson(string nume, string mail, string materii)
        {
            try
            {
                var rr = new ResourcesRepository();
                var model = rr.GetProfesoriByMail(mail);

                using (var context = new EducatieIncluzivaDbContext())
                {
                    Course curs = (from p in context.Courses
                                   where p.ProfesorId == model.UserId && p.Nume.Equals(materii)
                                   select p).FirstOrDefault();

                    Lesson l = (from m in context.Lessons
                                where m.CourseId == curs.CourseId && m.ProfesorOwnerId == model.UserId && m.Titlu.Equals(nume)
                                select m).FirstOrDefault();
                    if (l != null)
                    {
                        context.Lessons.Remove(l);
                        context.SaveChanges();
                        return 1;
                    }

                }
            }
            catch
            { }
            return 0;
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