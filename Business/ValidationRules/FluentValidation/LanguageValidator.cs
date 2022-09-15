namespace Business.ValidationRules.FluentValidation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(l => l.Name).NotEmpty().NotNull().WithMessage(LanguageConstants.LanguageNameNull);
        }
    }
}
