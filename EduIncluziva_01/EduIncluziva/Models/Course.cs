﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public sealed class Course
    {
        [ConcurrencyCheck]
        public string Nume { get; set; }

        [Key]
        public Guid CourseId { get; set; }
                
        public IList<Lesson> Lectii { get; set; }

        public Guid ProfesorId { get; set; }

        [ForeignKey("ProfesorId")]
        public List<Teacher> Profesori { get; set; }

        public Course()
        {
            CourseId = Guid.NewGuid();
            Profesori = new List<Teacher>();
            Lectii = new List<Lesson>();
        }
    }
}