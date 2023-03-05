using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.EmailAuthenticatorService;
using Application.Services.OtpAuthenticatorService;
using Application.Services.RefreshTokenService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
{
    private readonly IUserService _userService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IAuthService _authService;
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly AuthBusinessRules _authBusinessRules;

    public LoginCommandHandler(IUserService userService, IRefreshTokenService refreshTokenService, IAuthService authService, IEmailAuthenticatorService emailAuthenticatorService, AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _refreshTokenService = refreshTokenService;
        _authService = authService;
        _emailAuthenticatorService = emailAuthenticatorService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = _userService.GetByEmail(request.UserForLoginDto.Email);
        _authBusinessRules.UserShouldBeExists(user);
        _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);

        LoggedDto loggedDto = new();

        if (user.AuthenticatorType is not AuthenticatorType.None)
        {
            if (request.UserForLoginDto.AuthenticatorCode is null)
            {
                _emailAuthenticatorService.SendAuthenticatorCode(user);
                loggedDto.RequiredAuthenticatorType = user.AuthenticatorType;
                return loggedDto;
            }

            _authService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
        }

        AccessToken createdAccessToken = _authService.CreateAccessToken(user);

        RefreshToken createdRefreshToken = _refreshTokenService.CreateRefreshToken(user, request.IPAddress);
        RefreshToken addedRefreshToken = _refreshTokenService.AddRefreshToken(createdRefreshToken);
        _refreshTokenService.DeleteOldRefreshTokens(user.Id);

        loggedDto.AccessToken = createdAccessToken;
        loggedDto.RefreshToken = addedRefreshToken;
        return loggedDto;
    }
}
