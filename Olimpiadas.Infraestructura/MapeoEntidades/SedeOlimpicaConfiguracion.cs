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
    public class SedeOlimpicaConfiguracion : IEntityTypeConfiguration<SedeOlimpica>
    {
        public void Configure(EntityTypeBuilder<SedeOlimpica> builder)
        {
            builder.ToTable("SedeOlimpica");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.ID).HasColumnName("ID");
            builder.Property(s => s.Nombre).HasColumnName("Nombre");
            builder.Property(s => s.Presupuesto).HasColumnName("Presupuesto");
        }
    }
}
