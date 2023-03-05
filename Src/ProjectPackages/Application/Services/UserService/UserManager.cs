// this file was created automatically.
using Application.Repositories;
using Application.Services.UserOperationClaimService;
using Core.Domain.Concrete.Security.Entities;

namespace Application.Services.UserService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserOperationClaimService _userOperationClaimService;

    public UserManager(IUserRepository userRepository, IUserOperationClaimService userOperationClaimService)
    {
        _userRepository = userRepository;
        _userOperationClaimService = userOperationClaimService;
    }

    public User CreateUser(User newUser)
    {
        User createdUser = _userRepository.Add(newUser);

        _userOperationClaimService.AddClaimForRegisteredUser(createdUser);

        return createdUser;
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.Get(u => u.Email == email);
    }

    public User GetById(Guid id)
    {
        return _userRepository.Get(u => u.Id == id);
    }

    public User UpdateUser(User user)
    {
        return _userRepository.Update(user);
    }
}
