// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ElectronicsResourceRepository : EfRepositoryBase<ElectronicsResource, PostgreLRMSDbContext>, IElectronicsResourceRepository
{
    public ElectronicsResourceRepository(PostgreLRMSDbContext context) : base(context) { }
}
