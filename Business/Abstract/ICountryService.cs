using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IResult Add(Country country);
        IResult Delete(int conutryId);
        IResult ShadowDelete(int conutryId);
        IResult Update(Country country);
        IDataResult<Country> GetByCountry(int countryId);
        IDataResult<List<Country>> GetAll();
    }
}
