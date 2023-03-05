// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthService;

public interface IAuthService
{
    AccessToken CreateAccessToken(User user);
    void VerifyAuthenticatorCode(User user,string authenticatorCode);

}
