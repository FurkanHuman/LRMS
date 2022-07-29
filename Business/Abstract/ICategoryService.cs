using Business.Abstract.Base;
using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICategoryService : IBaseEntityService<Category, int>
    {
        IDataResult<IEnumerable<Category>> IGetAll();
    }
}
