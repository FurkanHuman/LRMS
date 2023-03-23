// this file was created automatically.
using Application.Features.Cities.Rules;
using Application.Repositories;
using Application.Services.CountryService;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Cities.Commands.UpdateCity;

public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdatedCityResponse>
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;
    private readonly CityBusinessRules _cityBusinessRules;

    public UpdateCityCommandHandler(ICityRepository cityRepository, ICountryService countryService, IMapper mapper, CityBusinessRules cityBusinessRules)
    {
        _cityRepository = cityRepository;
        _countryService = countryService;
        _mapper = mapper;
        _cityBusinessRules = cityBusinessRules;
    }

    public async Task<UpdatedCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        City mappedCity = _mapper.Map<City>(request);

        _cityBusinessRules.IdIsExit(mappedCity);
        _cityBusinessRules.NameIsExit(mappedCity);

        _countryService.IdControlByCountry(new() { Id = mappedCity.CountryId });
        
        City updatedCity = await _cityRepository.UpdateAsync(mappedCity);

        updatedCity.Country = _countryService.GetCountry(mappedCity.CountryId);

        UpdatedCityResponse updatedCityResponse = _mapper.Map<UpdatedCityResponse>(updatedCity);
        return updatedCityResponse;
    }
}
