// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class PasswordRepository : EfRepositoryBase<Password, PostgreLrmsUserDbContext>, IPasswordRepository
{
    public PasswordRepository(PostgreLrmsUserDbContext context) : base(context) { }
}
