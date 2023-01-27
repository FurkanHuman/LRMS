using Core.Domain.Abstract;

namespace Core.Test.Application.FakeData
{
    public abstract class BaseFakeData<TEntity>
        where TEntity : class, IEntity, new()
    {
        public List<TEntity> Data => CreateFakeData();
        public abstract List<TEntity> CreateFakeData();
    }
}
