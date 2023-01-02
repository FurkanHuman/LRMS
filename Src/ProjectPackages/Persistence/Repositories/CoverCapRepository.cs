// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CoverCapRepository : EfRepositoryBase<CoverCap, PostgreLRMSDbContext>, ICoverCapRepository
{
    public CoverCapRepository(PostgreLRMSDbContext context) : base(context) { }
}
