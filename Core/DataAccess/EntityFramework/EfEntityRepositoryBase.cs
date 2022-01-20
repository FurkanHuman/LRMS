using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Core.DataAccess.PostgreDb
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return context.Set<TEntity>().SingleOrDefault(filter.Compile());
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using TContext context = new();
            return filter == null ?
            context.Set<TEntity>().ToList() :
            context.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            using TContext context = new();
            EntityEntry<TEntity> AddEntity = context.Entry(entity);
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            EntityEntry<TEntity> deleteEntity = context.Remove(entity);
        }


        public void Update(TEntity entity)
        {
            using TContext context = new();
            EntityEntry<TEntity> UpdateEntity = context.Entry(entity);
            UpdateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
