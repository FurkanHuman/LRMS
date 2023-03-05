using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.OtpAuthenticatorService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using MediatR;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnableOtpAuthenticatorCommandHandler : IRequestHandler<EnableOtpAuthenticatorCommand, EnabledOtpAuthenticatorDto>
{
    private readonly IUserService _userService;
    private readonly IOtpAuthenticatorService _otpAuthenticatorService;
    private readonly AuthBusinessRules _authBusinessRules;

    public EnableOtpAuthenticatorCommandHandler(IUserService userService, IOtpAuthenticatorService otpAuthenticatorService, AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _otpAuthenticatorService = otpAuthenticatorService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<EnabledOtpAuthenticatorDto> Handle(EnableOtpAuthenticatorCommand request,
                                                         CancellationToken cancellationToken)
    {
        User user = _userService.GetById(request.UserId);
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

        OtpAuthenticator? isExistsOtpAuthenticator = _otpAuthenticatorService.GetOtpAuthenticatorByUserId(user.Id);
        await _authBusinessRules.OtpAuthenticatorThatVerifiedShouldNotBeExists(isExistsOtpAuthenticator);

        if (isExistsOtpAuthenticator is not null)
           _otpAuthenticatorService.DeleteOtpAuthenticatorAsync(isExistsOtpAuthenticator);

        OtpAuthenticator newOtpAuthenticator = _otpAuthenticatorService.CreateOtpAuthenticator(user);
        OtpAuthenticator addedOtpAuthenticator = _otpAuthenticatorService.AddOtpAuthenticator(newOtpAuthenticator);

        return new EnabledOtpAuthenticatorDto()
        {
            SecretKey = _otpAuthenticatorService.ConvertSecretKeyToString(addedOtpAuthenticator.SecretKey)
        };
    }
}
