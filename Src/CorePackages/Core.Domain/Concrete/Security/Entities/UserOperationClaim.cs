using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Core.Domain.Concrete.Security.Entities;

public class UserOperationClaim : BaseEntity<Guid>, IEntity
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim() { }

    public UserOperationClaim(Guid userId, int operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}