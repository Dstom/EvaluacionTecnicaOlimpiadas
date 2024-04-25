using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Olimpiadas.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Se requiere un Email")]
        [EmailAddress]        
        public string Email { get;set; }
        [Required(ErrorMessage = "Se requiere ingresar Contraseña")]
        [Display(Name = "Contraseña")]                
        public string Clave { get;set; }
    }
}
