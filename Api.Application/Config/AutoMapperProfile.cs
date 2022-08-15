using Api.Application.Contracts.DTOs;
using Api.CrossCutting.Contracts.Objects;
using Api.DataAccess.Contracts.Entities;
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
                )
                .ForMember(
                    dest => dest.city,
                    opt => opt.MapFrom(src => src.location.name)
                );
            CreateMap<Order, OrderDTO>()
                .ForMember(
                    dest => dest.header,
                    opt => opt.MapFrom(src => src.Header)
                )
                .ForMember(
                    dest => dest.humidity,
                    opt => opt.MapFrom(src => src.Humidity)
                )
                .ForMember(
                    dest => dest.detail,
                    opt => opt.MapFrom(src => src.Detail)
                )
                .ForMember(
                    dest => dest.mysqlId,
                    opt => opt.MapFrom(src => src.Id)
                );
        }
    }
}
