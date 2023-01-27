// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthService;

public interface IAuthService
{
    RefreshToken AddRefreshToken(RefreshToken createdRefreshToken);
    AccessToken CreateAccessToken(User createdUser);
    RefreshToken CreateRefreshToken(User createdUser, string ýPAddress);
}
