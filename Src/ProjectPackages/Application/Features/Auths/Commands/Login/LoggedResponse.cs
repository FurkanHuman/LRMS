 using Core.Application.Dtos;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auths.Commands.Login;

public class LoggedResponse : IDto
{
    public AccessToken? AccessToken { get; set; }
    public RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public LoggedResponse CreateResponseDto()
    {
        return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
    }
}