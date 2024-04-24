using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class SedeOlimpica
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Presupuesto { get; set; }
        public virtual List<ComplejoDeportivo> ComplejosDeportivos { get; set; }
    }
}
