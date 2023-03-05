// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.RefreshTokenService;

public interface IRefreshTokenService
{
    RefreshToken AddRefreshToken(RefreshToken refreshToken);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
    void DeleteOldRefreshTokens(Guid userId);
    RefreshToken? GetRefreshTokenByToken(string token);


    void RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);

    void RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null,
                                   string? replacedByToken = null);

    Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress);
}
