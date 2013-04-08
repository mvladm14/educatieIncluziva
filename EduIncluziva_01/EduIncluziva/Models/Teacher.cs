using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIncluziva.Models
{
    public sealed class Teacher : User
    {
        public List<Course> Materii { get; set; }
        public  string ImageUrlSetter { get; set; }
        public  string Description { get; set; }
      
        private const string ProfesorRole = "Profesor";

        public Teacher(string parola, string nume, string prenume, string mail, HighSchool scoalaDeProvenienta) :
            base(parola, nume, prenume, mail, scoalaDeProvenienta)
        {
            Role = ProfesorRole;
            Materii = new List<Course>();
        }

        public Teacher() { }
        
    
}
}