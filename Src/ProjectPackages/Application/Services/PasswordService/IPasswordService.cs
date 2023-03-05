// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.PasswordService;

public interface IPasswordService
{
    public Task<Password> CreatePassword(string password);
}
