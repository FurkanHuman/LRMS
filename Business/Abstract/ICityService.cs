using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICityService : IBaseEntityService<City>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<City> GetById(int id);
    }
}
