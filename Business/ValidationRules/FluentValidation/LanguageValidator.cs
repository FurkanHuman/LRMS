using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(l => l.LanguageName).NotEmpty().NotNull().WithMessage(LanguageConstants.LanguageNameNull);
        }
    }
}
