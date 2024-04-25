using AutoMapper;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Models;

namespace Olimpiadas.Profiles
{
    public class SedeOlimpicaProfile : Profile
    {
        public SedeOlimpicaProfile()
        {
            CreateMap<SedeOlimpica, SedeModel>()
                .ForMember(dest => dest.NumeroDeComplejos, opt => opt.MapFrom(src => src.ComplejosDeportivos.Count));
            CreateMap<SedeModel, SedeOlimpica>();
            CreateMap<SedeOlimpica, SedeDetailsViewModel>();
        }
    }
}
