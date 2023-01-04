// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class StockRepository : EfRepositoryBase<Stock, PostgreLrmsDbContext>, IStockRepository
{
    public StockRepository(PostgreLrmsDbContext context) : base(context) { }
}
