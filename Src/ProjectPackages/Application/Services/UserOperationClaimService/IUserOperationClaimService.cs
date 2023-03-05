// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.UserOperationClaimService;

public interface IUserOperationClaimService
{
    void AddClaimForRegisteredUser(User user);

    IList<OperationClaim> GetUserClaims(User user);
}
