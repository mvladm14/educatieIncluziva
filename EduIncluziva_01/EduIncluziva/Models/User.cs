using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIncluziva.Models
{
    public class User
    {
        [ConcurrencyCheck]
        public string Mail { get; set; }

        [Key]
        public Guid UserId { get; set; }

        public Guid ScoalaDeProvenientaId { get; set; }
        
        [ForeignKey("ScoalaDeProvenientaId")]
        public HighSchool ScoalaDeProvenienta { get; set; }

        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Role { get; set; }

        /// <summary>
        /// Constructor pentru User
        /// </summary>
        /// <param name="parola"></param>
        /// <param name="nume"></param>
        /// <param name="prenume"></param>
        /// <param name="mail"></param>
        /// <param name="scoalaDeProvenienta"></param>
        public User(string parola, string nume, string prenume, string mail, HighSchool scoalaDeProvenienta)
        {
            UserId = Guid.NewGuid();
            Parola = parola;
            Nume = nume;
            Prenume = prenume;
            Mail = mail;
            ScoalaDeProvenientaId = scoalaDeProvenienta.HighSchoolId;
        }

        public User() { }
    }
}
