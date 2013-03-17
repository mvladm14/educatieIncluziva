using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class HighSchool
    {
        [ConcurrencyCheck]
        public string Nume { get; set; }

        [Key]
        public System.Guid HighSchool_ID { get; set; }

        public virtual List<Teacher> Profesori { get; set; }
        public virtual List<Student> Elevi { get; set; }
    }
}
