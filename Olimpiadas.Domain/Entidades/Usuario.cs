using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Entidades
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
