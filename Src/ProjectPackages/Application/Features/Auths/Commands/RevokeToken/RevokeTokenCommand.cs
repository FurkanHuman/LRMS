using MediatR;

namespace Application.Features.Auths.Commands.RevokeToken;

public class RevokeTokenCommand : IRequest<RevokedTokenResponse>
{
    public string Token { get; set; }
    public string IPAddress { get; set; }
}
