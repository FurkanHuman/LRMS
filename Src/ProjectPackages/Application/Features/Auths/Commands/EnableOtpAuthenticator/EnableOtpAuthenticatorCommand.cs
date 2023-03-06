using MediatR;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnableOtpAuthenticatorCommand : IRequest<EnabledOtpAuthenticatorResponse>
{
    public Guid UserId { get; set; }
}