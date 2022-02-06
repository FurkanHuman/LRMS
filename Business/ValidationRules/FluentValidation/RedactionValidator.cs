using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RedactionValidator : AbstractValidator<Redaction>
    {
        public RedactionValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(RedactionConstants.RedactionNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(RedactionConstants.RedactionNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(RedactionConstants.RedactionSurnameNull);
        }
    }
}
