using MediatR;

namespace Application.Features.Auths.Commands.VerifyOtpAuthenticator;

public class VerifyOtpAuthenticatorCommand : IRequest
{
    public Guid UserId { get; set; }
    public string ActivationCode { get; set; }
}
