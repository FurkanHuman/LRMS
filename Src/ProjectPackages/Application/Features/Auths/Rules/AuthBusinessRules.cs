using Application.Features.Auths.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

    public AuthBusinessRules(IUserRepository userRepository, IEmailAuthenticatorRepository emailAuthenticatorRepository)
    {
        _userRepository = userRepository;
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
    }

    public Task EmailAuthenticatorShouldBeExists(EmailAuthenticator? emailAuthenticator)
    {
        if (emailAuthenticator is null) throw new BusinessException(AuthMessages.EmailAuthenticatorDontExists);
        return Task.CompletedTask;
    }

    public Task OtpAuthenticatorShouldBeExists(OtpAuthenticator? otpAuthenticator)
    {
        if (otpAuthenticator is null) throw new BusinessException(AuthMessages.OtpAuthenticatorDontExists);
        return Task.CompletedTask;
    }

    public Task OtpAuthenticatorThatVerifiedShouldNotBeExists(OtpAuthenticator? otpAuthenticator)
    {
        if (otpAuthenticator is not null && otpAuthenticator.IsVerified)
            throw new BusinessException(AuthMessages.AlreadyVerifiedOtpAuthenticatorIsExists);
        return Task.CompletedTask;
    }

    public Task EmailAuthenticatorActivationKeyShouldBeExists(EmailAuthenticator emailAuthenticator)
    {
        if (emailAuthenticator.ActivationKey is null) throw new BusinessException(AuthMessages.EmailActivationKeyDontExists);
        return Task.CompletedTask;
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user == null) throw new BusinessException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public Task UserShouldNotBeHaveAuthenticator(User user)
    {
        if (user.AuthenticatorType != AuthenticatorType.None)
            throw new BusinessException(AuthMessages.UserHaveAlreadyAAuthenticator);
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
    {
        if (refreshToken == null) throw new BusinessException(AuthMessages.RefreshDontExists);
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
    {
        if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires)
            throw new BusinessException(AuthMessages.InvalidRefreshToken);
        return Task.CompletedTask;
    }

    public void UserEmailShouldBeNotExists(string email)
    {
        User? user = _userRepository.Get(u => u.Email == email);
        if (user != null) throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    public async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id, include: u => u.Include(u => u.Password));
        if (!HashingHelper.VerifyPasswordHash(password, user.Password.PasswordHash, user.Password.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
    }
}