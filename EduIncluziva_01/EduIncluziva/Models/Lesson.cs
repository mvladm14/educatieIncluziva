using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class Lesson
    {
        [Key]
        public string   Titlu { get; set; }
        public Teacher ProfesorOwner;
        public DateTime DataPublicatie;

        public Lesson() { }
    }
}