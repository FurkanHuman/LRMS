using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICountryService : IBaseEntityService<Country>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<Country> GetById(int id);
        IDataResult<List<Country>> GetByCountryCodes(string countryCode);
    }
}
