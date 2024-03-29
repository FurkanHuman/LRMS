// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ElectronicsResourceRepository : EfRepositoryBase<ElectronicsResource, PostgreLrmsDbContext>, IElectronicsResourceRepository
{
    public ElectronicsResourceRepository(PostgreLrmsDbContext context) : base(context) { }
}
