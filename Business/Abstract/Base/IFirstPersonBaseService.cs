using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete.Base;

namespace Business.Abstract.Base
{
    public interface IFirstPersonBaseService<T> : IBaseEntityService<T, Guid> where T : FirstPagePersonBase, IEntity, new()
    {
        IDataResult<IList<T>> GetAllBySurname(string surname);
    }
}