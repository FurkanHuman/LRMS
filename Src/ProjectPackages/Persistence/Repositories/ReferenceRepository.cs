// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class ReferenceRepository : EfRepositoryBase<Reference, PostgreLRMSDbContext>, IReferenceRepository
{
    public ReferenceRepository(PostgreLRMSDbContext context) : base(context) { }
}
