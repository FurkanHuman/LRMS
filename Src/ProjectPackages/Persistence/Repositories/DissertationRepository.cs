// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class DissertationRepository : EfRepositoryBase<Dissertation, PostgreLRMSDbContext>, IDissertationRepository
{
    public DissertationRepository(PostgreLRMSDbContext context) : base(context) { }
}
