// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class KitRepository : EfRepositoryBase<Kit, PostgreLRMSDbContext>, IKitRepository
{
    public KitRepository(PostgreLRMSDbContext context) : base(context) { }
}
