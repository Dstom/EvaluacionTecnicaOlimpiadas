using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Olimpiadas.Models
{
    public class ComplejoDeportivoViewModel
    {
        public List<ComplejoDeportivoModel>? ComplejoDeportivos { get; set; }
        public List<SelectListItem>? TiposDeComplejos { get; set; }
        public string? TipoComplejo { get; set; }
        public string? ParametroBusqueda { get; set; }
        //public SelectList? Sedes { get; set; }
        //public string? IdSede { get; set; }
    }
    public class ComplejoDeportivoModel
    {        
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Localizacion { get; set; }
        [Required]
        [Display(Name ="Jefe de Organizacion")]
        public string JefeOrganizacion { get; set; }
        [Required]
        [Display(Name = "Area Total Ocupada")]
        public int AreaTotalOcupada { get; set; }
        [Required]
        public int TipoComplejoId { get; set; }
        [Required]
        public int SedeId { get; set; }
        [Display(Name = "Nombre de Sede")]
        public string? NombreSede { get; set; }
        [Display(Name = "Tipo de Complejo")]
        public string? NombreTipoComplejo { get; set; }

    }
}
