using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIncluziva.Models
{
    public sealed class HighSchool
    {
        [ConcurrencyCheck]
        public string Nume { get; set; }

        [Key]
        public Guid HighSchoolId { get; set; }

        public List<User> Users { get; set; }
        public HighSchool()
        {
            Users = new List<User>();
        }
    }
}
