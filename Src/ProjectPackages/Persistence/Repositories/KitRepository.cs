// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class KitRepository : EfRepositoryBase<Kit, PostgreLrmsDbContext>, IKitRepository
{
    public KitRepository(PostgreLrmsDbContext context) : base(context) { }
}
