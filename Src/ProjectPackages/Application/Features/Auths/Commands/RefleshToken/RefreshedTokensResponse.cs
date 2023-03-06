using Core.Application.Dtos;
using Core.Domain.Concrete.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Auths.Commands.RefleshToken;

public class RefreshedTokensResponse : IDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}