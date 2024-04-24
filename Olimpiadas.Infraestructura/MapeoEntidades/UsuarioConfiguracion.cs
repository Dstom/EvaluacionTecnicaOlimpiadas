using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olimpiadas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Infraestructura.MapeoEntidades
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Usuario_ID");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.Clave).HasColumnName("Clave");
            builder.Property(e => e.Nombre).HasColumnName("Nombre");
            builder.Property(e => e.Estado).HasColumnName("Estado");
            builder.Property(e => e.FechaCreacion).HasColumnName("Fecha_Creacion");
        }
    }
}
