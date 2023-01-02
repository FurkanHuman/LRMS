// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Infos;

namespace Application.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category>, IRepository<Category>
{
}
