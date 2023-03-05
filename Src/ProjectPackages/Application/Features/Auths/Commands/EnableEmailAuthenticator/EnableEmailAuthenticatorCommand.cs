using MediatR;

namespace Application.Features.Auths.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommand : IRequest
{
    public Guid UserId { get; set; }
    public string VerifyEmailUrlPrefix { get; set; }
}
