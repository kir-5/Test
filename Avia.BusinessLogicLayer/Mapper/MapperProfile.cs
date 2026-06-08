using AutoMapper;
using Avia.BusinessLogicLayer.Models;
using Avia.DataAccessLayer.Entities;

namespace Avia.BusinessLogicLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CityEntity, City>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
            CreateMap<City, CityEntity>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
            CreateMap<AirportEntity, Airport>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CityId, o => o.MapFrom(s => s.CityId));
            CreateMap<Airport, AirportEntity>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CityId, o => o.MapFrom(s => s.CityId));
        }
    }
}
