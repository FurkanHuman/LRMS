// this file was created automatically.
using Core.Persistence.Repositories;
using Domain.Entities.Mains;

namespace Application.Repositories;

public interface IBookRepository : IAsyncRepository<Book>, IRepository<Book>
{
}
