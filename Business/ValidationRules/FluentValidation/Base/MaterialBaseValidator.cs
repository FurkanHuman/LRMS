global using FluentValidation;
using Business.Constants.Base;
using Core.Entities.Abstract;
using Entities.Concrete.Base;


namespace Business.ValidationRules.FluentValidation.Base
{
    public class MaterialBaseValidator<T> : AbstractValidator<T> where T : MaterialBase, IEntity, new()
    {
        public MaterialBaseValidator()
        {
            RuleFor(mb => mb.Name).NotEmpty().NotNull().WithMessage(BaseConstants.NameRequired);
            RuleFor(mb => mb.Name).MinimumLength(3).MaximumLength(56).WithMessage(BaseConstants.NameLengthRangeMinMax);
            RuleFor(mb => mb.Title).NotEmpty().NotNull().WithMessage(BaseConstants.TitleRequired);
            RuleFor(mb => mb.Title).MinimumLength(3).MaximumLength(75).WithMessage(BaseConstants.TitleLengthRangeMinMax);
            RuleFor(mb => mb.Description).NotEmpty().NotNull().WithMessage(BaseConstants.DescriptionRequired);
            RuleFor(mb => mb.Description).MinimumLength(3).MaximumLength(500).WithMessage(BaseConstants.DescriptionLengthRangeMinMax);
            RuleFor(mb => mb.CategoryId).NotEmpty().NotNull().WithMessage(BaseConstants.CategoryIdRequired);
            RuleFor(mb => mb.TechnicalPlaceholdersId).NotEmpty().NotNull().WithMessage(BaseConstants.TechnicalPlaceholdersIdRequired);
            RuleFor(mb => mb.Stock).NotEmpty().NotNull().WithMessage(BaseConstants.StockRequired); // todo structure may change in the future
        }
    }
}
