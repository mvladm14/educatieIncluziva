using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class Course
    {
        [ConcurrencyCheck]
        public string Nume { get; set; }

        [Key]
        public System.Guid Course_ID { get; set; }

        public virtual List<Lesson> Lectii { get; set; }
        public virtual List<Teacher> Profesori { get; set; }

        public Course() { }
    }
}