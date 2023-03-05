// this file was created automatically.
using Application.Repositories;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.Hashing;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Application.Services.PasswordService;

public class PasswordManager : IPasswordService
{
    private readonly IPasswordRepository _passwordRepository;

    public PasswordManager(IPasswordRepository passwordRepository)
    {
        _passwordRepository = passwordRepository;
    }

    public async Task<Password> CreatePassword(string password)
    {
        HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        Password newPassword = new() { PasswordHash = passwordHash, PasswordSalt = passwordSalt, ExpiresDate = DateTime.UtcNow.AddMonths(6) };

        Password createdPassword = await _passwordRepository.AddAsync(newPassword);

        return createdPassword;
    }
}
