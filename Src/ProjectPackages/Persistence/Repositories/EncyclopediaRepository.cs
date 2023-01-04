// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class EncyclopediaRepository : EfRepositoryBase<Encyclopedia, PostgreLrmsDbContext>, IEncyclopediaRepository
{
    public EncyclopediaRepository(PostgreLrmsDbContext context) : base(context) { }
}
