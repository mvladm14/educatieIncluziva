using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EduIncluziva.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ElevRegisterModel
    {
        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} trebuie sa aiba cel putin {2} caractere.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmare parola")]
        [Compare("Parola", ErrorMessage = "Parolele nu coincid.")]
        public string ConfirmareParola { get; set; }

        [Required]
        [Display(Name = "Scoala de provenienta")]
        public string ScoalaDeProvenienta { get; set; }

    }

    public class ElevLogonModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UserLogonModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class SearchedUserModel
    {
        [Required]
        [Display(Name = "Username sau adresa de mail")]
        public string Mail { get; set; }
    }

    public class UserInfoModel
    {
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [StringLength(100, ErrorMessage = "{0} trebuie sa aiba cel putin {2} caractere.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmare parola")]
        [Compare("Parola", ErrorMessage = "Parolele nu coincid.")]
        public string ConfirmareParola { get; set; }

        [Display(Name = "Scoala de provenienta")]
        public string ScoalaDeProvenienta { get; set; }

        [Display(Name = "Scurta descriere")]
        public string ScurtaDescriere { get; set; }
    }

    public class SearchedHighSchoolModel
    {
        [Required]
        [Display(Name = "Numele exact al liceului")]
        public string Nume { get; set; }
    }

    public class TeacherRegisterModel
    {
        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} trebuie sa aiba cel putin {2} caractere.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Parola { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmare parola")]
        [Compare("Parola", ErrorMessage = "Parolele nu coincid.")]
        public string ConfirmareParola { get; set; }

        [Required]
        [Display(Name = "Scoala de provenienta")]
        public string ScoalaDeProvenienta { get; set; }
                
        [Display(Name = "Descriere")]
        public string Descriere { get; set; }

    }
}
