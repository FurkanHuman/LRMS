using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract.Base
{
    public interface IBaseDtoService<D, I> where D : IDto, new()
                                           where I : struct
    {
        IResult Add(D entity);
        IResult Update(D entity);
        IDataResult<D> DtoGetById(I id);
        IDataResult<List<D>> DtoGetByNames(string name);
        IDataResult<List<D>> DtoGetAllBySecrets();
        IDataResult<List<D>> DtoGetAll();
    }
}
