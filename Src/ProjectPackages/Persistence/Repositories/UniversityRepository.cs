// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class UniversityRepository : EfRepositoryBase<University, PostgreLRMSDbContext>, IUniversityRepository
{
    public UniversityRepository(PostgreLRMSDbContext context) : base(context) { }
}
