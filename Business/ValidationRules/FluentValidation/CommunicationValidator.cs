namespace Business.ValidationRules.FluentValidation
{
    public class CommunicationValidator : AbstractValidator<Communication>
    {
        public CommunicationValidator()
        {
            RuleFor(c => c.CommunicationName).MinimumLength(5).MaximumLength(50)
                .NotNull().NotEmpty().WithMessage(CommunicationConstants.CommNameError);
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().WithMessage(CommunicationConstants.PhoneNull);
            RuleFor(c => c.Email).NotNull().NotEmpty().WithMessage(CommunicationConstants.EmailNull);
            RuleFor(c => c.WebSite).NotNull().NotEmpty().WithMessage(CommunicationConstants.WebSiteNull);
        }
    }
}
