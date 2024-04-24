using Microsoft.EntityFrameworkCore;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Infraestructura.MapeoEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Infraestructura.Contextos
{
    public class Contexto : DbContext, IContextoBase
    {
        public Contexto(DbContextOptions<Contexto> options
           ) : base(options)
        {
        }
        public DbSet<T> Establecer<T>() where T : class
        {
            return Set<T>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AreaDeportivaConfiguracion());
            modelBuilder.ApplyConfiguration(new ComisarioConfiguracion());
            modelBuilder.ApplyConfiguration(new ComplejoDeportivoConfiguracion());
            modelBuilder.ApplyConfiguration(new EquipamientoConfiguracion());
            modelBuilder.ApplyConfiguration(new EventoConfiguracion());
            modelBuilder.ApplyConfiguration(new SedeOlimpicaConfiguracion());
            modelBuilder.ApplyConfiguration(new TipoComplejoConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        }
    }
}
