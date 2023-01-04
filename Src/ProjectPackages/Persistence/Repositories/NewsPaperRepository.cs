// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class NewsPaperRepository : EfRepositoryBase<NewsPaper, PostgreLrmsDbContext>, INewsPaperRepository
{
    public NewsPaperRepository(PostgreLrmsDbContext context) : base(context) { }
}
