// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.EmailAuthenticatorService;

public interface IEmailAuthenticatorService
{
    EmailAuthenticator? GetEmailAuthenticatorByActivationKey(string activationKey);
    Task VerifyUpdateAsync(EmailAuthenticator emailAuthenticator);
    EmailAuthenticator AddAndCreateAsyncEmailAuthenticator(User user);
    void SendAuthenticatorCode(User user);
    Task VerifyAuthenticatorCode(User user, string authenticatorCode);
}
