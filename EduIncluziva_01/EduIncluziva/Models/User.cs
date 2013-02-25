using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduIncluziva.Models
{
    public class User
    {           
        [Key]
        public string Mail { get; set; }

        public System.Guid User_ID { get; set; }        
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// Constructor pentru User
        /// </summary>
        /// <param name="Parola"></param>
        /// <param name="Nume"></param>
        /// <param name="Prenume"></param>
        /// <param name="Role"></param>
        /// <param name="Mail"></param>
        public User(string Parola, string Nume, string Prenume, string Mail)
        {
            this.User_ID = Guid.NewGuid();
            this.Parola = Parola;
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Mail = Mail;
        }

        public User() { }
    }
}
