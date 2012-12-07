using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduIncluziva.Models
{
    public class EmailDetail
    {
       
        public EmailDetail(string nume, string prenume, string bio, string mail)
        {
            // TODO: Complete member initialization
            this.nume = nume;
            this.prenume = prenume;
            this.bio = bio;
            this.mail = mail;
        }
        public string nume { get; set; }
        public string mail { get; set; }
        public string bio { get; set; }
        public string prenume { get; set; }
    }
}