using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduIncluziva.Models
{
    public class InregistrareProfesorModel
    {
        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required]
        [Display(Name = "Adresa de mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Scoala de provenienta")]
        public string ScoalaDeProveninenta { get; set; }

        [Required]
        [Display(Name = "Descriere")]
        public string Descriere { get; set; }       

        [Required]
        [StringLength(100, ErrorMessage = "{0} trebuie sa contina cel putin {2} caractere.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmare parola")]
        [Compare("Parola", ErrorMessage = "Parolele nu coincid.")]
        public string ConfirmareParola { get; set; }
    }
}