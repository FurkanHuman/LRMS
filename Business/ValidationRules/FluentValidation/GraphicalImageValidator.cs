using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class GraphicalImageValidator : MaterialBaseValidator<GraphicalImage>
    {
        public GraphicalImageValidator()
        {
            RuleFor(k => k.ImageCreatedDate).NotEmpty().NotNull().WithMessage(GraphicalImageConstants.ImageCreatedDateNull);
            RuleFor(k => k.Image.Id).NotEmpty().NotNull().WithMessage(GraphicalImageConstants.ImageIdRequired);
            RuleFor(k => k.OtherPeople.Id).NotEmpty().NotNull().WithMessage(GraphicalImageConstants.OtherPeopleIdRequired);
        }
    }
}
