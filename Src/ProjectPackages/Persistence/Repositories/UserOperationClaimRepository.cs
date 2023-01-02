// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, PostgreLRMSUserDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(PostgreLRMSUserDbContext context) : base(context) { }
}
