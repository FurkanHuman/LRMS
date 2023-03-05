// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.OtpAuthenticatorService;

public interface IOtpAuthenticatorService
{
    OtpAuthenticator AddOtpAuthenticator(OtpAuthenticator newOtpAuthenticator);
    OtpAuthenticator CreateOtpAuthenticator(User user);
    Task<OtpAuthenticator> CreateOtpAuthenticatorAsync(User user);
    Task DeleteOtpAuthenticatorAsync(OtpAuthenticator isExistsOtpAuthenticator);
    OtpAuthenticator? GetOtpAuthenticatorByUserId(Guid userId);
    byte[] GetOtpSecretKey(Guid id);
    string ConvertSecretKeyToString(byte[] secretKey);
    Task UpdateOtpAuthenticator(OtpAuthenticator otpAuthenticator);
    Task VerifyAuthenticatorCode(User user, string authenticatorCode);
}
