using Core.Domain.Concrete.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos;

public class LoggedResponseDto
{
    public AccessToken? AccessToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public LoggedResponseDto CreateResponseDto()
    {
        return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
    }
}
