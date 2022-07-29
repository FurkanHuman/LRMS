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
        // list to IEnumrable change after
        IDataResult<List<D>> DtoGetAllByIds(I[] ids);
        IDataResult<List<D>> DtoGetAllByName(string name);
        IDataResult<List<D>> DtoGetAllBySecret();
        IDataResult<List<D>> DtoGetAll();
    }
}
