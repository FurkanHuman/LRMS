// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class PaintingRepository : EfRepositoryBase<Painting, PostgreLRMSDbContext>, IPaintingRepository
{
    public PaintingRepository(PostgreLRMSDbContext context) : base(context) { }
}
