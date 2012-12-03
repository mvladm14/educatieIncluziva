using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class Licee
    {
        public Licee()
        {
            this.Profesoris = new List<Profesori>();
        }

        public string Nume { get; set; }
        public System.Guid Liceu_ID { get; set; }
        public virtual ICollection<Profesori> Profesoris { get; set; }
    }
}
