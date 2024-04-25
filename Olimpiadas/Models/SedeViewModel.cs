using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Olimpiadas.Models
{
    public class SedeViewModel
    {
        public List<SedeModel>? SedesOlimpicas { get; set; }        
        public string? ParametroBusqueda { get; set; }
    }
    public class SedeModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        [Display(Name = "Cantidad de Complejos")]
        public int? NumeroDeComplejos { get; set; }
    }
}
