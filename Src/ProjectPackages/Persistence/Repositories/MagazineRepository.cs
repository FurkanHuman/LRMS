// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class MagazineRepository : EfRepositoryBase<Magazine, PostgreLrmsDbContext>, IMagazineRepository
{
    public MagazineRepository(PostgreLrmsDbContext context) : base(context) { }
}
