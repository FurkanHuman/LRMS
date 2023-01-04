// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class DepictionRepository : EfRepositoryBase<Depiction, PostgreLrmsDbContext>, IDepictionRepository
{
    public DepictionRepository(PostgreLrmsDbContext context) : base(context) { }
}
