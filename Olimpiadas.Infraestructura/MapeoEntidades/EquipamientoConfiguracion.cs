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
    public class EquipamientoConfiguracion : IEntityTypeConfiguration<Equipamiento>
    {
        public void Configure(EntityTypeBuilder<Equipamiento> builder)
        {
            builder.ToTable("Equipamiento");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.Nombre).HasColumnName("Nombre");
            builder.Property(e => e.Descripcion).HasColumnName("Descripcion");
        }
    }
}
