// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CountryRepository : EfRepositoryBase<Country, PostgreLrmsDbContext>, ICountryRepository
{
    public CountryRepository(PostgreLrmsDbContext context) : base(context) { }
}