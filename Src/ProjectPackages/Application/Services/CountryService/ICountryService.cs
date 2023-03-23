// this file was created automatically.
using Domain.Entities.Infos;

namespace Application.Services.CountryService;

public interface ICountryService
{
    Country GetCountry(int countryId);
    void IdControlByCountry(Country country);
}
