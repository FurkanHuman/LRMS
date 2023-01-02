// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EncyclopediaRepository : EfRepositoryBase<Encyclopedia, PostgreLRMSDbContext>, IEncyclopediaRepository
{
    public EncyclopediaRepository(PostgreLRMSDbContext context) : base(context) { }
}
