using AutoMapper;
using Microsoft.CodeAnalysis;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Models;

namespace Olimpiadas.Profiles
{
    public class ComplejoDeportivoProfile : Profile
    {
        public ComplejoDeportivoProfile()
        {
            CreateMap<ComplejoDeportivo, ComplejoDeportivoModel>()
                .ForMember(dest => dest.NombreSede,opt => opt.MapFrom(src => src.SedeOlimpica.Nombre))
                .ForMember(dest => dest.NombreTipoComplejo, opt => opt.MapFrom(src => src.TipoComplejo.Tipo));
            CreateMap<ComplejoDeportivoModel, ComplejoDeportivo>();           
        }
    }
}
