// this file was created automatically.
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.UserService;

public interface IUserService
{
    User CreateUser(User newUser);
    User? GetByEmail(string email);
    User GetById(Guid id);
    User UpdateUser(User user);
}
