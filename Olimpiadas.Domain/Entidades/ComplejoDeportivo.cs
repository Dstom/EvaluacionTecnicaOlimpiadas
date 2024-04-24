using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class ComplejoDeportivo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Localizacion { get; set; }
        public string JefeOrganizacion { get; set; }
        public decimal AreaTotalOcupada { get; set; }
        public virtual ComplejoDeportivo TipoComplejo { get; set; }
        public virtual SedeOlimpica SedeOlimpica { get; set; }
        public virtual List<AreaDeportiva> AreasDeportivas { get; set; }
        public virtual List<Evento> Eventos { get; set; }
    }
}
