using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class Administrator : User
    {
        private static string ADMIN_ROLE = "Admin";

        public Administrator(string Parola, string Nume, string Prenume, string Mail, HighSchool ScoalaDeProvenienta) :
            base(Parola, Nume, Prenume, Mail, ScoalaDeProvenienta)
        {
            this.Role = ADMIN_ROLE;
        }

        public Administrator() { }
    }
}
