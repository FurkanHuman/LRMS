using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Repositories;
using Application.Services.AuthService;
using Application.Services.PasswordService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IPasswordService _passwordService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(IUserService userService, IAuthService authService, IPasswordService passwordService, AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _authService = authService;
        _passwordService = passwordService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

        Password createdPassword = await _passwordService.CreatePassword(request.UserForRegisterDto.Password);

        User newUser = new()
        {
            Email = request.UserForRegisterDto.Email,
            PasswordId = createdPassword.Id,
            Status = true
        };

        User createdUser =  _userService.CreateUser(newUser);

        AccessToken createdAccessToken = _authService.CreateAccessToken(createdUser);

        RefreshToken createdRefreshToken = _authService.CreateRefreshToken(createdUser, request.IPAddress);

        RefreshToken addedRefreshToken = _authService.AddRefreshToken(createdRefreshToken);

        return new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
    }
}