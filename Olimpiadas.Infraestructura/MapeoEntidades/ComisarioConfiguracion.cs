using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olimpiadas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Infraestructura.MapeoEntidades
{
    public class ComisarioConfiguracion : IEntityTypeConfiguration<Comisario>
    {
        public void Configure(EntityTypeBuilder<Comisario> builder)
        {
            builder.ToTable("Comisario");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).HasColumnName("ID");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
        }
    }
}
