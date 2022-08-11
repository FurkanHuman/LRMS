using AutoMapper;
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
            return context.Set<TEntity>().FirstOrDefault(filter.Compile());
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
            AddEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            EntityEntry<TEntity> deleteEntity = context.Remove(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            EntityEntry<TEntity> UpdateEntity = context.Entry(entity);
            UpdateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

    }

    public class EfEntityRepositoryBase<TEntity, TDto, TContext> : IDtoRepository<TEntity>, IDtoRepository<TDto, TEntity>
           where TEntity : class, IEntity, new()
           where TDto : class, IDto, new()
           where TContext : DbContext, new()
    {

        private readonly IMapper _mapper;

        public EfEntityRepositoryBase()
        {
            MapperConfiguration config = new(cfg => cfg.CreateMap<TEntity, TDto>());
            _mapper = config.CreateMapper();
        }

        public TDto? DtoGet(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return _mapper.Map<TDto>(context.Set<TEntity>().FirstOrDefault(filter.Compile()));
        }

        public C? CDtoGet<C>(Expression<Func<TEntity, bool>> filter ) where C : class, IDto, new()
        {
            using TContext context = new();
            return _mapper.Map<C>(context.Set<TEntity>().FirstOrDefault(filter.Compile()));
        }

        public IList<C> CDtoGetAll<C>(Expression<Func<TEntity, bool>>? filter = null) where C : class, IDto, new()
        {
            using TContext context = new();
            return filter == null ?
               _mapper.Map<IList<C>>(context.Set<TEntity>().ToList()) :
               _mapper.Map<IList<C>>(context.Set<TEntity>().Where(filter).ToList());
        }

        public IList<TDto> DtoGetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using TContext context = new();
            return filter == null ?
               _mapper.Map<IList<TDto>>(context.Set<TEntity>().ToList()) :
               _mapper.Map<IList<TDto>>(context.Set<TEntity>().Where(filter).ToList());
        }
    }
}