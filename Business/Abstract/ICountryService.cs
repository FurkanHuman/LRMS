using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICountryService : IBaseEntityService<Country, int>
    {
        IDataResult<List<Country>> GetByCountryCodes(string countryCode);
    }
}
