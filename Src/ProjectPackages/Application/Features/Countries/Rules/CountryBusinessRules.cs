// this file was created automatically.
using Application.Repositories;
using Application.Features.Countries.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{

    private readonly ICountryRepository _countryRepository;

    public CountryBusinessRules(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    internal void CountryCodeIsExit(Country mappedCountry)
    {
        bool country = _countryRepository.Any(c => c.CountryCode == mappedCountry.CountryCode);
        if (country)
            throw new BusinessException(CountryMessages.CountryCodeIsExit);
    }

    internal void MultiExistByCountries(IList<Country> mappedCountries)
    {
        IList<Country> countries = _countryRepository.GetList(c => mappedCountries.Select(c => c.Name).Contains(c.Name)
                                                                && mappedCountries.Select(c => c.CountryCode).Contains(c.CountryCode), size: int.MaxValue).Items.ToList();
        if (countries.Count > 0)
            throw new BusinessException(CountryMessages.MultiExit(countries));
    }

    internal void NameIsExit(Country mappedCountry)
    {
        bool country = _countryRepository.Any(c => c.Name == mappedCountry.Name);
        if (country)
            throw new BusinessException(CountryMessages.CountryNameIsExit);
    }

    internal void IdIsExit(int id)
    {
        bool country = _countryRepository.Any(c => c.Id == id);
        if (country)
            throw new BusinessException(CountryMessages.CountryIdNotExit);
    }
}
