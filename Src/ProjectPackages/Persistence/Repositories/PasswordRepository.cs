// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class PasswordRepository : EfRepositoryBase<Password, PostgreLRMSUserDbContext>, IPasswordRepository
{
    public PasswordRepository(PostgreLRMSUserDbContext context) : base(context) { }
}
