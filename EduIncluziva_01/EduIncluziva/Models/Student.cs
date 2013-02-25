using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EduIncluziva.Models
{
    public class Student : User
    {
        private static string ELEV_ROLE = "Elev";

        public Student(string Parola, string Nume, string Prenume, string Mail) :
            base(Parola, Nume, Prenume, Mail)
        {
            this.Role = ELEV_ROLE;
        }

        public Student() { }
    }
}