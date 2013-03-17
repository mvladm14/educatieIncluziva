using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class Teacher : User
    {
        public virtual List<Course> Materii { get; set; }
        private static string PROFESOR_ROLE = "Profesor";

        public Teacher(string Parola, string Nume, string Prenume, string Mail, HighSchool ScoalaDeProvenienta) :
            base(Parola, Nume, Prenume, Mail, ScoalaDeProvenienta)
        {
            this.Role = PROFESOR_ROLE;
        }

        public Teacher() { }
        
    }
}