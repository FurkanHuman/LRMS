// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, PostgreLrmsUserDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(PostgreLrmsUserDbContext context) : base(context) { }
}
