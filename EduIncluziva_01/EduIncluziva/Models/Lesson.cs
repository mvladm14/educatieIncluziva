using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class Lesson
    {
        [ConcurrencyCheck]
        public string   Titlu { get; set; }

        [Key]
        public System.Guid Lesson_ID { get; set; }

        public Teacher ProfesorOwner;
        public DateTime DataPublicatie;

        public Lesson() { }
    }
}