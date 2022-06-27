using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ElectronicsResourceValidator : MaterialBaseValidator<ElectronicsResource>
    {
        public ElectronicsResourceValidator()
        {
            RuleFor(er => er.ResourceUrl).NotEmpty().NotNull().WithMessage(ElectronicsResourceConstants.ResourceUrlNull);
        }
    }
}
