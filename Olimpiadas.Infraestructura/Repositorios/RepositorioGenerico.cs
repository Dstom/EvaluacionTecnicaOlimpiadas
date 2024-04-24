using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Infraestructura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Infraestructura.Repositorios
{
    public class RepositorioGenerico : IRepositorioGenerico
    {
        private Contexto _contexto;

        public RepositorioGenerico(Contexto contextoGeneral)
        {
            _contexto = contextoGeneral;
        }

        public void Adicionar<T>(T entidad) where T : class
        {
            _contexto.Set<T>().Add(entidad);
        }
        public void GuardarCambios()
        {
            _contexto.SaveChanges();
        }

        public T ObtenerPorCodigo<T>(int llaves) where T : class
        {
            return _contexto.Set<T>().Find(llaves);
        }

        public IList<T> ObtenerPorExpresionLimite<T>(Expression<Func<T, bool>> filtro = null, string incluir = null, byte limite = 0) where T : class
        {
            if (filtro != null)
            {
                if (limite == 0)
                {
                    return _contexto.Establecer<T>().Where(filtro).ToList();
                }
                else
                {
                    return _contexto.Establecer<T>().Where(filtro).Take(limite).ToList();
                }
            }
            else
            {
                return _contexto.Establecer<T>().ToList();
            }
        }
    }
}
