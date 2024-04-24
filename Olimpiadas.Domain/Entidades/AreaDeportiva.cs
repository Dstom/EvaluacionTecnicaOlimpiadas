using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class AreaDeportiva
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public virtual ComplejoDeportivo ComplejoDeportivo { get; set; }
    }
}
