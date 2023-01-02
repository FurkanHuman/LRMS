// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, PostgreLRMSDbContext>, ICategoryRepository
{
    public CategoryRepository(PostgreLRMSDbContext context) : base(context) { }
}
