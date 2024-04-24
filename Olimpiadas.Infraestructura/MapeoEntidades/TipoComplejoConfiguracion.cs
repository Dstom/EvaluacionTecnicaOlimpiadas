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
    public class TipoComplejoConfiguracion : IEntityTypeConfiguration<ComplejoDeportivo>
    {
        public void Configure(EntityTypeBuilder<ComplejoDeportivo> builder)
        {
            builder.ToTable("TipoComplejo");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.ID).HasColumnName("ID");
            //builder.Property(t => t.Tipo).HasColumnName("Tipo");
        }
    }
}
