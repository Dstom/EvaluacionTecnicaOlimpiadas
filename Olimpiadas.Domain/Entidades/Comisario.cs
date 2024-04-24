using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class Comisario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual List<Evento> Eventos { get; set; }
    }
}
