// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using Domain.Entities.Infos;

namespace Application.Services.CountryService;

public class CountryManager : ICountryService
{
    private readonly CountryBusinessRules _countryBusinessRules;
    private readonly ICountryRepository _countryRepository;

    public CountryManager(CountryBusinessRules countryBusinessRules, ICountryRepository countryRepository)
    {
        _countryBusinessRules = countryBusinessRules;
        _countryRepository = countryRepository;
    }

    public Country GetCountry(int countryId)
    {
        return _countryRepository.GetAsync(c => c.Id == countryId).Result;
    }

    public void IdControlByCountry(Country country)
    {
        _countryBusinessRules.IdIsExit(country.Id);
    }
}
