// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CoverCapRepository : EfRepositoryBase<CoverCap, PostgreLrmsDbContext>, ICoverCapRepository
{
    public CoverCapRepository(PostgreLrmsDbContext context) : base(context) { }
}
