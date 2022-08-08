using Business.Abstract.Base;
using Core.Entities.Abstract;
using Entities.Concrete.Base;
using Entities.Concrete.Infos;

namespace Business.Abstract
{
    public interface ICounterService : IBaseEntityService<Counter, Guid>
    {
        Task Count<T>(T? t) where T : MaterialBase, IEntity, new();
        Task Count<T>(IList<T>? ts) where T : MaterialBase, IEntity, new();
    }
}
