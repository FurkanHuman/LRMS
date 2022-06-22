using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class ComposerValidator : AbstractValidator<Composer>
    {
        public ComposerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(ComposerConstants.ComposerNameNull);
            RuleFor(c => c.Name).MinimumLength(3).WithMessage(ComposerConstants.ComposerNameLengthNotEnough);
            RuleFor(c => c.SurName).NotEmpty().NotNull().WithMessage(ComposerConstants.ComposerSurnameNull);
        }
    }
}
