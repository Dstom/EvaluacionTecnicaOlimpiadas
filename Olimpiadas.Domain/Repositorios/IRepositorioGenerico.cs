using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Dominio.Repositorios
{
    public interface IRepositorioGenerico
    {
        T ObtenerPorCodigo<T>(int llaves) where T : class;
        IList<T> ObtenerPorExpresionLimite<T>(Expression<Func<T, bool>> filtro = null, string incluir = null, byte limite = 0) where T : class;
        void Adicionar<T>(T entidad) where T : class;
        void GuardarCambios();
    }
}
