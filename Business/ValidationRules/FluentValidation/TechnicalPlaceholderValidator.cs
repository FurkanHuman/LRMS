using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class TechnicalPlaceholderValidator : AbstractValidator<TechnicalPlaceholder>
    {
        public TechnicalPlaceholderValidator()
        {
            RuleFor(t => t.ColumnCode).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.ColumnCodeEmpty);
            RuleFor(t => t.RowCode).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.RowCodeNull);
            RuleFor(t => t.Library).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.LibraryEmpty);
            RuleFor(t => t.SpecialLocation).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.SpecialLocationEmpty);
        }
    }
}
