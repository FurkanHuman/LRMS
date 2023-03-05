using Application.Features.Auths.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnableOtpAuthenticatorCommand : IRequest<EnabledOtpAuthenticatorDto>
{
    public Guid UserId { get; set; }
}