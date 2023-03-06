using Core.Domain.Abstract;
using Core.Persistence.Repositories;

namespace Core.Test.Application.FakeData;

public abstract class BaseFakeData<TEntity>
    where TEntity : class, IEntity, new()
{
    public List<TEntity> Data => CreateFakeData();
    public abstract List<TEntity> CreateFakeData();
}
