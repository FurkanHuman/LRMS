using Core.Application.Dtos;

namespace Application.Features.Auths.Commands.RevokeToken;

public class RevokedTokenResponse : IDto
{
    public int Id { get; set; }
    public string Token { get; set; }
}