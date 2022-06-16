using Business.Constants.Base;
using Core.Entities.Abstract;
using Entities.Concrete.Base;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Base
{
    public class FirstPagePersonBaseValidator<T> : AbstractValidator<T> where T : FirstPagePersonBase, IEntity, new()
    {
        public FirstPagePersonBaseValidator()
        {
            RuleFor(fp => fp.Name).NotEmpty().NotNull().WithMessage(BaseConstants.NameRequired);
            RuleFor(fp => fp.Name).MinimumLength(2).MaximumLength(75).WithMessage(BaseConstants.FpNameLengthRangeMinMax);
            RuleFor(fp => fp.SurName).NotEmpty().NotNull().WithMessage(BaseConstants.SurnameRequired);
            RuleFor(fp => fp.SurName).MinimumLength(2).MaximumLength(75).WithMessage(BaseConstants.FpSurnameLengthRangeMinMax);
        }
    }
}
