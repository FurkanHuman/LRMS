// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class DepictionRepository : EfRepositoryBase<Depiction, PostgreLRMSDbContext>, IDepictionRepository
{
    public DepictionRepository(PostgreLRMSDbContext context) : base(context) { }
}
