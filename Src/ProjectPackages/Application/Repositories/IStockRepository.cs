// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;

namespace Application.Repositories;

public interface IStockRepository : IAsyncRepository<Stock>, IRepository<Stock>
{
}