using System;
using System.Collections.Generic;

namespace EduIncluziva.Models
{
    public class Elevi
    {
        public string Mail { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public System.Guid Elev_ID { get; set; }
        public string Parola { get; set; }
    }
}
