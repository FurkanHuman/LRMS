using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.OtpAuthenticatorService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using MediatR;

namespace Application.Features.Auths.Commands.VerifyOtpAuthenticator;

public class VerifyOtpAuthenticatorCommandHandler : IRequestHandler<VerifyOtpAuthenticatorCommand>
{
    private readonly IOtpAuthenticatorService _otpAuthenticatorService;
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public VerifyOtpAuthenticatorCommandHandler(IOtpAuthenticatorService otpAuthenticatorService, IUserService userService, IAuthService authService, AuthBusinessRules authBusinessRules)
    {
        _otpAuthenticatorService = otpAuthenticatorService;
        _userService = userService;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<Unit> Handle(VerifyOtpAuthenticatorCommand request, CancellationToken cancellationToken)
    {
       OtpAuthenticator? otpAuthenticator = _otpAuthenticatorService.GetOtpAuthenticatorByUserId(request.UserId);
        await _authBusinessRules.OtpAuthenticatorShouldBeExists(otpAuthenticator);

        User user =  _userService.GetById(request.UserId);

        otpAuthenticator.IsVerified = true;
        user.AuthenticatorType = AuthenticatorType.Otp;

        _authService.VerifyAuthenticatorCode(user, request.ActivationCode);

        _otpAuthenticatorService.UpdateOtpAuthenticator(otpAuthenticator);
        _userService.UpdateUser(user);

        return Unit.Value;
    }
}