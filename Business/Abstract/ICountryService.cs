using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IResult Add(Country country);
        IResult AddCities(int countryId, int[] cityIds);
        IResult Delete(int conutryId);
        IResult ShadowDelete(int conutryId);
        IResult Update(int oldCountryId, Country newCountry);
        IDataResult<Country> GetByCountry(int countryId);
        IDataResult<List<City>> GetByCities(int countryId);
        IDataResult<List<Country>> GetAll();
    }
}
