using Business.Abstract.Base;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICategoryService : IBaseEntityService<Category>
    {
        IResult Delete(int id);
        IResult ShadowDelete(int id);
        IDataResult<Category> GetById(int id);
    }
}
