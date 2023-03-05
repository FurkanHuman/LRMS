// this file was created automatically.
using Application.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UserOperationClaimService;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    // todo: change a claim ýd 
    public void AddClaimForRegisteredUser(User user)
    {
        _userOperationClaimRepository.Add(new() { OperationClaimId = 1, UserId = user.Id });
        return;
    }

    public IList<OperationClaim> GetUserClaims(User user)
    {
        return _userOperationClaimRepository
             .Query()
             .AsNoTracking()
             .Where(p => p.UserId == user.Id)
             .Select(p => new OperationClaim
             {
                 Id = p.OperationClaimId,
                 Name = p.OperationClaim.Name
             })
             .ToList();
    }
}
