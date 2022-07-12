using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class TechnicalPlaceholderValidator : AbstractValidator<TechnicalPlaceholder>
    {
        public TechnicalPlaceholderValidator()
        {
            RuleFor(t => t.RowCode).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.StockNumberEmpty);
            RuleFor(t => t.SpecialLocation).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.WhereMaterialEmpty);
            RuleFor(t => t.Library).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.LibraryEmpty);
            RuleFor(t => t.RowCode).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.StockNumberNotNull);
        }
    }
}
