using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class KitValidator : MaterialBaseValidator<Kit>
    {
        public KitValidator()
        {
            RuleFor(k => k.IsKitBroken).NotEmpty().NotNull().WithMessage(KitConstants.KitBrokenNull);
        }
    }
}
