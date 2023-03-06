using Core.Application.Dtos;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnabledOtpAuthenticatorResponse : IDto
{
    public string SecretKey { get; set; }

    public EnabledOtpAuthenticatorResponse()
    {
    }

    public EnabledOtpAuthenticatorResponse(string secretKey)
    {
        SecretKey = secretKey;
    }
}