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
    public class EventoConfiguracion : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.Fecha).HasColumnName("Fecha");
            builder.Property(e => e.Duracion).HasColumnName("Duracion");
            builder.Property(e => e.NumParticipantes).HasColumnName("NumParticipantes");
            builder.Property(e => e.NumComisarios).HasColumnName("NumComisarios");
            //builder.Property(e => e.Complejo_ID).HasColumnName("Complejo_ID");
        }
    }
}
