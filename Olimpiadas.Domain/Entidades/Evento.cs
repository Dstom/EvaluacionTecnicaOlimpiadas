using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class Evento
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Duracion { get; set; }
        public int NumParticipantes { get; set; }
        public int NumComisarios { get; set; }
        public ComplejoDeportivo ComplejoDeportivo { get; set; }
        public virtual List<Comisario> Comisarios { get; set; }
        public virtual List<Equipamiento> Equipamientos { get; set; }
    }
}
