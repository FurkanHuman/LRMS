using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().NotNull().WithMessage(CategoryConstants.CategoryNameNull);
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage(CategoryConstants.CategroNamelength);
        }
    }
}
