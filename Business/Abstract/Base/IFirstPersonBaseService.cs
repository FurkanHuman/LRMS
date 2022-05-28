using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseService<T> : IBaseEntityService<T> where T : FirstPagePersonBase, IEntity, new()
    {
        IResult Delete(Guid id);
        IResult ShadowDelete(Guid id);
        IDataResult<T> GetById(Guid id);
        IDataResult<List<T>> GetBySurnames(string surname);
    }
}