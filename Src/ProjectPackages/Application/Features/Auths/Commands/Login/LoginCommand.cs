using Core.Application.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }
}