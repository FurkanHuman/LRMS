// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class TechnicalNumberRepository : EfRepositoryBase<TechnicalNumber, PostgreLrmsDbContext>, ITechnicalNumberRepository
{
    public TechnicalNumberRepository(PostgreLrmsDbContext context) : base(context) { }
}
