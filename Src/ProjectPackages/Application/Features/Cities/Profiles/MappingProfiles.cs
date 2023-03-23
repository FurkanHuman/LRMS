// this file was created automatically.
using Application.Features.Cities.Commands.CreateCity;
using Application.Features.Cities.Commands.DeleteCity;
using Application.Features.Cities.Commands.UpdateCity;
using Application.Features.Cities.Queries.GetByIdCity;
using Application.Features.Cities.Queries.GetListByCity;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Infos;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CreatedCityResponse>()
            .ForMember(destinationMember: c => c.CountryName, memberOptions: opt => opt.MapFrom(c => c.Country.Name)).ReverseMap();

        CreateMap<City, DeleteCityCommand>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();

        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>()
            .ForMember(destinationMember: c => c.CountryName, memberOptions: opt => opt.MapFrom(c => c.Country.Name)).ReverseMap();

        CreateMap<City, GetByIdCityResponse>()
            .ForMember(destinationMember: c => c.CountryName, memberOptions: opt => opt.MapFrom(c => c.Country.Name)).ReverseMap();

        CreateMap<City, GetListByCityResponse>()        
            .ForMember(destinationMember: c => c.CountryCode, memberOptions: opt => opt.MapFrom(c => c.Country.CountryCode)).ReverseMap();

        CreateMap<IPaginate<City>, GetListResponse<GetListByCityResponse>>().ReverseMap();
    }
}
