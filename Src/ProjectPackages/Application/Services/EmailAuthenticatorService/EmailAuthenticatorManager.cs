// this file was created automatically.
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Concrete.Security.Entities;
using Core.Domain.Concrete.Security.Enums;
using Core.Mailing;
using Core.Security.EmailAuthenticator;
using MimeKit;

namespace Application.Services.EmailAuthenticatorService;

public class EmailAuthenticatorManager : IEmailAuthenticatorService
{
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
    private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
    private readonly IMailService _mailService;

    public EmailAuthenticatorManager(IEmailAuthenticatorRepository emailAuthenticatorRepository, IEmailAuthenticatorHelper emailAuthenticatorHelper, IMailService mailService)
    {
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
        _emailAuthenticatorHelper = emailAuthenticatorHelper;
        _mailService = mailService;
    }

    public EmailAuthenticator AddAndCreateAsyncEmailAuthenticator(User user)
    {

        EmailAuthenticator newEmailAuthenticator = new()
        {
            User = user,
            ActivationKey =  _emailAuthenticatorHelper.CreateEmailActivationKey().Result,
            IsVerified = false

        };

        return _emailAuthenticatorRepository.Add(newEmailAuthenticator);
    }
        
    public EmailAuthenticator? GetEmailAuthenticatorByActivationKey(string activationKey)
    {
        return _emailAuthenticatorRepository.Get(e => e.ActivationKey == activationKey);
    }

    public void SendAuthenticatorCode(User user)
    {
        if (user.AuthenticatorType is AuthenticatorType.Email) 
            SendAuthenticatorCodeWithEmail(user);
    }

    public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
    {
        EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

        if (emailAuthenticator.ActivationKey != authenticatorCode)
            throw new BusinessException("Authenticator code is invalid.");

        emailAuthenticator.ActivationKey = null;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
    }

    public Task VerifyUpdateAsync(EmailAuthenticator emailAuthenticator)
    {
        _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
        return Task.CompletedTask;
    }

    private async Task SendAuthenticatorCodeWithEmail(User user)
    {
        EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

        if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

        string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();
        emailAuthenticator.ActivationKey = authenticatorCode;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

        var toEmailList = new List<MailboxAddress>
            {
                new($"",user.Email)
            };

        _mailService.SendMail(new Mail
        {
            ToList = toEmailList,
            Subject = "Authenticator Code - RentACar",
            TextBody = $"Enter your authenticator code: {authenticatorCode}"
        });
    }
}
