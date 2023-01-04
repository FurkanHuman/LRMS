// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, PostgreLrmsUserDbContext>, IUserRepository
{
    public UserRepository(PostgreLrmsUserDbContext context) : base(context) { }
}
