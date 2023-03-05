using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }
}