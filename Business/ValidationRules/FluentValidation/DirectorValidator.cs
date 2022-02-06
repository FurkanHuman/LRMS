using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DirectorValidator : AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(DirectorConstants.DirectorNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(DirectorConstants.DirectorNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(DirectorConstants.DirectorSurnameNull);
        }
    }
}
