using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIncluziva.Models
{
    public class Lesson
    {
        [ConcurrencyCheck]
        public string Titlu { get; set; }

        [Key]
        public Guid LessonId { get; set; }

        public Guid ProfesorOwnerId { get; set; }

        [ForeignKey("ProfesorOwnerId")]
        public virtual Teacher ProfesorOwner { get; set; }
        public DateTime DataPublicatie;

        public Guid CourseId { get; set; }

         [ForeignKey("CourseId")]
        public virtual Course myCourse { get; set; }
        public Lesson() {
            LessonId = Guid.NewGuid();
            
        }
    }
}