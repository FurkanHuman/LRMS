// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, PostgreLrmsDbContext>, ICityRepository
{
    public CityRepository(PostgreLrmsDbContext context) : base(context) { }
}
