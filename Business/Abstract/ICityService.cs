using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICityService
    {
        IResult Add(string cityName);
        IResult Delete(int cityId);
        IResult ShadowDelete(int cityId);
        IResult Update(int cityId, string cityName);
        IDataResult<City> Get(int cityId);
        IDataResult<List<City>> GetByFilterLists(Expression<Func<City, bool>>? filter = null);
        IDataResult<List<City>> GetAll();
    }
}
