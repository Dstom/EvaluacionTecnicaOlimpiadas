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
    public class ComplejoDeportivoConfiguracion : IEntityTypeConfiguration<ComplejoDeportivo>
    {
        public void Configure(EntityTypeBuilder<ComplejoDeportivo> builder)
        {
            builder.ToTable("ComplejoDeportivo");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).HasColumnName("ID");
            builder.Property(c => c.Nombre).HasColumnName("Nombre");
            builder.Property(c => c.Localizacion).HasColumnName("Localizacion");
            builder.Property(c => c.JefeOrganizacion).HasColumnName("JefeOrganizacion");
            builder.Property(c => c.AreaTotalOcupada).HasColumnName("AreaTotalOcupada");
            builder.Property(c => c.TipoComplejoId).HasColumnName("TipoComplejo_ID");
            builder.Property(c => c.SedeId).HasColumnName("SedeOlimpica_ID");
            builder.HasOne(c => c.SedeOlimpica).WithMany().HasForeignKey(c => c.SedeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.TipoComplejo).WithMany().HasForeignKey(x => x.TipoComplejoId);
        }
    }
}
