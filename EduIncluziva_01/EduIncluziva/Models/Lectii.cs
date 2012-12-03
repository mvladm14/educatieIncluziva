using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class Lectii
    {
        public System.Guid Profesor_ID { get; set; }
        public System.DateTime Data { get; set; }
        public string Titlu { get; set; }
        public System.Guid Lectie_ID { get; set; }
        public string URL { get; set; }
        public virtual Profesori Profesori { get; set; }
    }
}
