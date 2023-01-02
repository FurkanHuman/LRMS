// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, PostgreLRMSUserDbContext>, IUserRepository
{
    public UserRepository(PostgreLRMSUserDbContext context) : base(context) { }
}
