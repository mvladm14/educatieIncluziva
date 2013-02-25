using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class HighSchool
    {
        [Key]
        public string Nume { get; set; }
        public virtual List<Teacher> Profesori { get; set; }
    }
}
