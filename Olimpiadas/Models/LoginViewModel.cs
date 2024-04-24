using System.ComponentModel.DataAnnotations;

namespace Olimpiadas.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Correo Electrónico")]
        public string Email { get;set; }
        [Required]
        [Display(Name = "Contraseña")]                
        public string Clave { get;set; }
    }
}
