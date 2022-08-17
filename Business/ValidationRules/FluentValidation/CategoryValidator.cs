namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(CategoryConstants.CategoryNameNull);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(CategoryConstants.CategroNamelength);
        }
    }
}
