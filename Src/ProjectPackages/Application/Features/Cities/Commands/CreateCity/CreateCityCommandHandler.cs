// this file was created automatically.
using Application.Features.Cities.Rules;
using Application.Repositories;
using Application.Services.CountryService;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreatedCityResponse>
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;
    private readonly CityBusinessRules _cityBusinessRules;

    public CreateCityCommandHandler(ICityRepository cityRepository, ICountryService countryService, IMapper mapper, CityBusinessRules cityBusinessRules)
    {
        _cityRepository = cityRepository;
        _countryService = countryService;
        _mapper = mapper;
        _cityBusinessRules = cityBusinessRules;
    }

    public async Task<CreatedCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        City mappedCity = _mapper.Map<City>(request);

        _cityBusinessRules.NameIsExit(mappedCity);
        _countryService.IdControlByCountry(new() { Id = mappedCity.CountryId });

        City createdCity = await _cityRepository.AddAsync(mappedCity);

        createdCity.Country = _countryService.GetCountry(mappedCity.CountryId);

        CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(createdCity);
        return createdCityResponse;
    }
}
