// this file was created automatically.
using Application.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Application.Services.RefreshTokenService;

public class RefreshTokenManager : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper _tokenHelper;
    private TokenOptions _tokenOptions;

    public RefreshTokenManager(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, IConfiguration configuration)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public RefreshToken AddRefreshToken(RefreshToken refreshToken)
    {
        return _refreshTokenRepository.Add(refreshToken);
    }

    public RefreshToken CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken).Result;
    }

    public void DeleteOldRefreshTokens(Guid userId)
    {
        IList<RefreshToken> refreshTokens = ( _refreshTokenRepository.GetListAsync(r =>
                                                 r.UserId == userId &&
                                                 r.Revoked == null && r.Expires >= DateTime.UtcNow &&
                                                 r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <=
                                                 DateTime.UtcNow)
                                            ).Result.Items;
        foreach (RefreshToken refreshToken in refreshTokens)
            _refreshTokenRepository.Delete(refreshToken);
    }

    public RefreshToken? GetRefreshTokenByToken(string token)
    {
        return _refreshTokenRepository.GetAsync(r => r.Token == token).Result;
    }

    public void RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {

        RefreshToken childToken = _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken).Result;

        if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
            RevokeRefreshToken(childToken, ipAddress, reason);
        else RevokeDescendantRefreshTokens(childToken, ipAddress, reason);
    }

    public void RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;
        token.ReasonRevoked = reason;
        token.ReplacedByToken = replacedByToken;
        _refreshTokenRepository.Update(token);
    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }
}
