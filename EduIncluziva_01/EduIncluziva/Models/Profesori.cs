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
        public byte[] Poza { get; set; }
        public string Bio { get; set; }
        public System.Guid Profesor_ID { get; set; }
        public System.Guid Liceu_ID { get; set; }
        public virtual ICollection<Lectii> Lectiis { get; set; }
        public virtual Licee Licee { get; set; }
    }
}
