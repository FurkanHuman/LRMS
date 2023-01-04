// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class UniversityRepository : EfRepositoryBase<University, PostgreLrmsDbContext>, IUniversityRepository
{
    public UniversityRepository(PostgreLrmsDbContext context) : base(context) { }
}
