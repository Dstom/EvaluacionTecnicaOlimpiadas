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
    public class AreaDeportivaConfiguracion : IEntityTypeConfiguration<AreaDeportiva>
    {
        public void Configure(EntityTypeBuilder<AreaDeportiva> builder)
        {
            builder.ToTable("AreaDeportiva");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).HasColumnName("ID");
            builder.Property(a => a.Tipo).HasColumnName("Tipo");
            //builder.Property(a => a.Complejo_ID).HasColumnName("Complejo_ID");
        }
    }
}
