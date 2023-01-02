// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class StockRepository : EfRepositoryBase<Stock, PostgreLRMSDbContext>, IStockRepository
{
    public StockRepository(PostgreLRMSDbContext context) : base(context) { }
}
