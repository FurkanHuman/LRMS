// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, PostgreLRMSUserDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(PostgreLRMSUserDbContext context) : base(context) { }
}
