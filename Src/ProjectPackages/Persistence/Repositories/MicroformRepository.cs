// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class MicroformRepository : EfRepositoryBase<Microform, PostgreLrmsDbContext>, IMicroformRepository
{
    public MicroformRepository(PostgreLrmsDbContext context) : base(context) { }
}
