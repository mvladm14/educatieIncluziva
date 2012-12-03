using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class Lectii
    {
        public Nullable<System.DateTime> Data { get; set; }
        public int ProfessorId { get; set; }
        public string Titlu { get; set; }
        public int ID_Lectie { get; set; }
        public virtual Profesori Profesori { get; set; }
    }
}
