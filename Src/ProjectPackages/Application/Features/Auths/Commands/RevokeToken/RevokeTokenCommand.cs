using Application.Features.Auths.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.RevokeToken;

public class RevokeTokenCommand : IRequest<RevokedTokenDto>
{
    public string Token { get; set; }
    public string IPAddress { get; set; }
}
