using Application.Repositories;
using Application.Services.EmailAuthenticatorService;
using Application.Services.OperationClaimService;
using Application.Services.OtpAuthenticatorService;
using Application.Services.RefreshTokenService;
using Application.Services.UserOperationClaimService;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Mailing;
using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.AuthService;

public class AuthManager : IAuthService
{

    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly IOtpAuthenticatorService _otpAuthenticatorService;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(IUserOperationClaimService userOperationClaimService, IEmailAuthenticatorService emailAuthenticatorService, IOtpAuthenticatorService otpAuthenticatorService, ITokenHelper tokenHelper)
    {
        _userOperationClaimService = userOperationClaimService;
        _emailAuthenticatorService = emailAuthenticatorService;
        _otpAuthenticatorService = otpAuthenticatorService;
        _tokenHelper = tokenHelper;
    }

    public AccessToken CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = _userOperationClaimService.GetUserClaims(user);
        return _tokenHelper.CreateToken(user, operationClaims);
    }

    public void VerifyAuthenticatorCode(User user, string authenticatorCode)
    {
        if (user.AuthenticatorType is AuthenticatorType.Email)
            _emailAuthenticatorService.VerifyAuthenticatorCode(user, authenticatorCode);
        else if (user.AuthenticatorType is AuthenticatorType.Otp)
            _otpAuthenticatorService.VerifyAuthenticatorCode(user, authenticatorCode);
    }
}