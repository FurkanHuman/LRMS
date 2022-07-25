using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class MicroformValidator : MaterialBaseValidator<Microform>
    {
        public MicroformValidator()
        {
            RuleFor(m => m.Scale).NotEmpty().NotNull().WithMessage(MicroformConstants.ScaleISNull);
        }
    }
}
