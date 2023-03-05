using Application.Features.Auths.Rules;
using Application.Repositories;
using Application.Services.AuthService;
using Application.Services.EmailAuthenticatorService;
using Application.Services.UserService;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Mailing;
using MediatR;
using MimeKit;
using System.Web;

namespace Application.Features.Auths.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
{
    private readonly IUserService _userService;
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly IMailService _mailService;
    private readonly AuthBusinessRules _authBusinessRules;

    public EnableEmailAuthenticatorCommandHandler(IUserService userService, IEmailAuthenticatorService emailAuthenticatorService, IMailService mailService, AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _emailAuthenticatorService = emailAuthenticatorService;
        _mailService = mailService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<Unit> Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
    {
        User user = _userService.GetById(request.UserId);
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

        user.AuthenticatorType = AuthenticatorType.Email;
        _userService.UpdateUser(user);

        EmailAuthenticator addedEmailAuthenticator = _emailAuthenticatorService.AddAndCreateAsyncEmailAuthenticator(user);

        List<MailboxAddress> toEmailList = new()
            {
                new("Plase verifiy Email",user.Email)
            };

        _mailService.SendMail(new Mail
        {
            ToList = toEmailList,
            Subject = "Verify Your Email - L.R.M.S",
            TextBody = $"Click on the link to verify your email: {request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}"
        });

        return Unit.Value;
    }
}
