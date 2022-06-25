using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class DepictionValidator : MaterialBaseValidator<Depiction>
    {
        public DepictionValidator()
        {
            RuleFor(d => d.Image).NotEmpty().NotNull().WithMessage(DepictionConstants.ImageIdRequired);
        }
    }
}
