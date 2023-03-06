using MediatR;

namespace Application.Features.Auths.Commands.RefleshToken;

public class RefreshTokenCommand : IRequest<RefreshedTokensResponse>
{
    public string? RefleshToken { get; set; }
    public string? IPAddress { get; set; }
}
