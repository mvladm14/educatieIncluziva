using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class Profesori
    {
        public Profesori()
        {
            this.Lectiis = new List<Lectii>();
        }

        public string Mail { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Parola { get; set; }
        public string Bio { get; set; }
        public string Poza { get; set; }
        public int ProfesoriId { get; set; }
        public virtual ICollection<Lectii> Lectiis { get; set; }
    }
}
