namespace Core.Application.Dtos;

public class UserForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
