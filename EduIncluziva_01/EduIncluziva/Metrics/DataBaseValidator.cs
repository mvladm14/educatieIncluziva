using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduIncluziva.Models;

namespace EduIncluziva.Metrics
{
    public static class DataBaseValidator
    {
        
        public static bool ValidateUser(string Mail, string Parola)
        {
            ResourcesRepository rr = new ResourcesRepository();
            Elevi elev = rr.GetEleviByMail(Mail);

            if (elev != null)
            {
                //daca l-am gasit in baza de date
                if (elev.Parola.Equals(Parola))
                {
                    //daca parolele coincid
                    return true;
                }
            }

            Profesori profesor = rr.GetProfesoriByMail(Mail);
            if (profesor != null)
            {
                //daca l-am gasit in baza de date
                if (profesor.Parola.Equals(Parola))
                {
                    //daca parolele coincid
                    return true;
                }
            }

            //daca nu l-am gasit nici la elevi, nici la profesori
            return false;
        }
    }
}