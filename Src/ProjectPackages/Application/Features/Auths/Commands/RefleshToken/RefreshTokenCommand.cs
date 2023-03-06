using Application.Features.Auths.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.RefleshToken;

public class RefreshTokenCommand : IRequest<RefreshedTokensDto>
{
    public string? RefleshToken { get; set; }
    public string? IPAddress { get; set; }
}
