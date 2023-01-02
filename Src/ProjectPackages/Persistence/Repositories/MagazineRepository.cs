// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class MagazineRepository : EfRepositoryBase<Magazine, PostgreLRMSDbContext>, IMagazineRepository
{
    public MagazineRepository(PostgreLRMSDbContext context) : base(context) { }
}
