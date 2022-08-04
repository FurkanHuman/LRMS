using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract.Base
{
    public interface IBaseDtoService<D, I> where D : IDto, new()
                                           where I : struct
    {
        IResult Add(D entity);
        IResult Update(D entity);
        IDataResult<D> DtoGetById(I id);
        IDataResult<IList<D>> DtoGetAllByIds(I[] ids);
        IDataResult<IList<D>> DtoGetAllByName(string name);
        IDataResult<IList<D>> DtoGetAllBySecret();
        IDataResult<IList<D>> DtoGetAll();
    }
}
