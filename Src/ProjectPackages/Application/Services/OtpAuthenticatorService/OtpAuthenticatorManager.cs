// this file was created automatically.
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.OtpAuthenticator;

namespace Application.Services.OtpAuthenticatorService;

public class OtpAuthenticatorManager : IOtpAuthenticatorService
{
    private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
    private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;

    public OtpAuthenticatorManager(IOtpAuthenticatorRepository otpAuthenticatorRepository, IOtpAuthenticatorHelper otpAuthenticatorHelper)
    {
        _otpAuthenticatorRepository = otpAuthenticatorRepository;
        _otpAuthenticatorHelper = otpAuthenticatorHelper;
    }

    public OtpAuthenticator AddOtpAuthenticator(OtpAuthenticator newOtpAuthenticator)
    {
        return _otpAuthenticatorRepository.Add(newOtpAuthenticator);
    }

    public string ConvertSecretKeyToString(byte[] secretKey)
    {
        return _otpAuthenticatorHelper.ConvertSecretKeyToString(secretKey).Result;
    }

    public OtpAuthenticator CreateOtpAuthenticator(User user)
    {
        OtpAuthenticator otpAuthenticator = new()
        {
            UserId = user.Id,
            SecretKey = _otpAuthenticatorHelper.GenerateSecretKey().Result,
            IsVerified = false
        };
        return otpAuthenticator;
    }

    public async Task<OtpAuthenticator> CreateOtpAuthenticatorAsync(User user)
    {
        OtpAuthenticator otpAuthenticator = new()
        {
            UserId = user.Id,
            SecretKey = await _otpAuthenticatorHelper.GenerateSecretKey(),
            IsVerified = false
        };
        return otpAuthenticator;
    }

    public Task DeleteOtpAuthenticatorAsync(OtpAuthenticator isExistsOtpAuthenticator)
    {
        return _otpAuthenticatorRepository.DeleteAsync(isExistsOtpAuthenticator);
    }

    public OtpAuthenticator? GetOtpAuthenticatorByUserId(Guid userId)
    {
        return _otpAuthenticatorRepository.Get(o => o.UserId == userId);
    }

    public byte[] GetOtpSecretKey(Guid id)
    {
        return _otpAuthenticatorRepository.Get(o => o.UserId == id).SecretKey;
    }

    public Task UpdateOtpAuthenticator(OtpAuthenticator otpAuthenticator)
    {
        _otpAuthenticatorRepository.UpdateAsync(otpAuthenticator);
        return Task.CompletedTask;
    }

    public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
    {
        OtpAuthenticator otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

        bool result = await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);

        if (!result)
            throw new BusinessException("Authenticator code is invalid.");
    }

}
