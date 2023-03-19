// this file was created automatically.
using Application.Features.Countries.Commands.CreateCountry;
using Application.Features.Countries.Commands.CreateCountries;
using AutoMapper;
using Domain.Entities.Infos;
using Application.Features.Countries.Commands.DeleteCountry;
using Application.Features.Countries.Commands.UpdateCountry;
using Application.Features.Countries.Queries.GetByIdCountry;
using Core.Persistence.Paging;
using Application.Features.Countries.Queries.GetListByCountry;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, CreatedCountryResponse>().ReverseMap();

        CreateMap<Country, CreateCountriesCommandHeader>().ReverseMap();

        CreateMap<Country, CreatedCountriesResponseHeader>().ReverseMap();

        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Country, DeletedCountryResponse>().ReverseMap();

        CreateMap<Country, UpdatedCountryResponse>().ReverseMap();

        CreateMap<Country, GetByIdCountryResponse>()
            .ForMember(destinationMember: c => c.CitiesName, memberOptions: opt => opt.MapFrom(c => c.Cities.Select(c => c.Name))).ReverseMap();

        CreateMap<Country, GetListByCountryResponse>()
            .ForMember(destinationMember: c => c.CitiesName, memberOptions: opt => opt.MapFrom(c => c.Cities.Select(c => c.Name))).ReverseMap();

        CreateMap<IPaginate<Country>, GetListResponse<GetListByCountryResponse>>().ReverseMap();
    }
}
