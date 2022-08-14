using Api.Application.Contracts.DTOs;
using Api.CrossCutting.Contracts.Objects;
using AutoMapper;

namespace Api.Application.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<WeatherStackDTO, WeatherDTO>()
                .ForMember(
                    dest => dest.temperature,
                    opt => opt.MapFrom(src => src.current.temperature)
                )
                .ForMember(
                    dest => dest.humidity,
                    opt => opt.MapFrom(src => src.current.humidity)
                );
        }
    }
}
