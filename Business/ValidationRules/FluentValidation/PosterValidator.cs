using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class PosterValidator : MaterialBaseValidator<Poster>
    {
        public PosterValidator()
        {
            RuleFor(p => p.Owner).NotEmpty().NotNull().WithMessage(PosterConstants.OtherPeopleIdRequired);
            RuleFor(p => p.ImageId).NotEmpty().NotNull().WithMessage(PosterConstants.ImageIdRequired);
        }
    }
}
