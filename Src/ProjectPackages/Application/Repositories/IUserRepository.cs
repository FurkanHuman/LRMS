using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;

namespace Application.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}
