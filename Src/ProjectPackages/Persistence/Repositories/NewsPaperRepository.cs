// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class NewsPaperRepository : EfRepositoryBase<NewsPaper, PostgreLRMSDbContext>, INewsPaperRepository
{
    public NewsPaperRepository(PostgreLRMSDbContext context) : base(context) { }
}
