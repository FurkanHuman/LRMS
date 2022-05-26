using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ConsultantValidator : AbstractValidator<Consultant>
    {
        public ConsultantValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(ConsultantConstants.NameNull);
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(50).WithMessage(ConsultantConstants.NameLengthNotEnough);
            RuleFor(c => c.SurName).NotEmpty().NotNull().WithMessage(ConsultantConstants.NameNull);
            RuleFor(c => c.SurName).MinimumLength(2).MaximumLength(75).WithMessage(ConsultantConstants.NameLengthNotEnough);
            RuleFor(c => c.NamePreAttachment).MaximumLength(15).WithMessage(ConsultantConstants.NamePreAtchLengthmaximum);
        }
    }
}
