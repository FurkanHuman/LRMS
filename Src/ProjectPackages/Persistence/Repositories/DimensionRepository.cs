// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class DimensionRepository : EfRepositoryBase<Dimension, PostgreLRMSDbContext>, IDimensionRepository
{
    public DimensionRepository(PostgreLRMSDbContext context) : base(context) { }
}
