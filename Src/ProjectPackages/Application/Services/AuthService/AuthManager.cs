using Application.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
    }

    public AccessToken CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = _userOperationClaimRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.UserId == user.Id)
                .Select(p => new OperationClaim
                {
                    Id = p.OperationClaimId,
                    Name = p.OperationClaim.Name
                })
                .ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public RefreshToken AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = _refreshTokenRepository.Add(refreshToken);
        return addedRefreshToken;
    }

    public RefreshToken CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return refreshToken;
    }
}