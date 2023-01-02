// this file was created automatically.
using Core.Persistence.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Persistence.Contexts;
using Application.Repositories;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, PostgreLRMSUserDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(PostgreLRMSUserDbContext context) : base(context) { }
}
