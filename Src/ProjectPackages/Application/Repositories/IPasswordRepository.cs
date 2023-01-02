using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;

namespace Application.Repositories;

public interface IPasswordRepository : IAsyncRepository<Password>, IRepository<Password>
{
}