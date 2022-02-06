using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TechnicalPlaceholderValidator : AbstractValidator<TechnicalPlaceholder>
    {
        public TechnicalPlaceholderValidator()
        {
            RuleFor(t => t.StockNumber).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.StockNumberEmpty);
            RuleFor(t => t.WhereMaterial).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.WhereMaterialEmpty);
        }
    }
}
