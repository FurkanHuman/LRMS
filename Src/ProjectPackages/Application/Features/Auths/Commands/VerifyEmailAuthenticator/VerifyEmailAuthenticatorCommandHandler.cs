using Application.Features.Auths.Rules;
using Application.Services.EmailAuthenticatorService;
using Core.Domain.Concrete.Security.Entities;
using MediatR;

namespace Application.Features.Auths.Commands.VerifyEmailAuthenticator;

public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
{
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly AuthBusinessRules _authBusinessRules;

    public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorService emailAuthenticatorService, AuthBusinessRules authBusinessRules)
    {
        _emailAuthenticatorService = emailAuthenticatorService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<Unit> Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
    {
        EmailAuthenticator? emailAuthenticator = _emailAuthenticatorService.GetEmailAuthenticatorByActivationKey(request.ActivationKey);
        
        await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
        await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator);

        emailAuthenticator.ActivationKey = null;
        emailAuthenticator.IsVerified = true;

        _emailAuthenticatorService.VerifyUpdateAsync(emailAuthenticator);

        return Unit.Value;
    }
}