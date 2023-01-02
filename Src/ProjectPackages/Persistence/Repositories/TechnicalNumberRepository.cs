// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class TechnicalNumberRepository : EfRepositoryBase<TechnicalNumber, PostgreLRMSDbContext>, ITechnicalNumberRepository
{
    public TechnicalNumberRepository(PostgreLRMSDbContext context) : base(context) { }
}
