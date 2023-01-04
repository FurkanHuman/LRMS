// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class CounterRepository : EfRepositoryBase<Counter, PostgreLrmsDbContext>, ICounterRepository
{
    public CounterRepository(PostgreLrmsDbContext context) : base(context) { }
}
