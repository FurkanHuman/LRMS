using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DimensionValidator : AbstractValidator<Dimension>
    {
        public DimensionValidator()
        {
            RuleFor(d => d.Width).NotNull().NotEmpty().WithMessage(DimensionConstants.WidthNull);
            RuleFor(d => d.Length).NotNull().NotEmpty().WithMessage(DimensionConstants.LengthNull);
            RuleFor(d => d.Height).Null().NotEmpty().WithMessage(DimensionConstants.HeightNull);
        }
    }
}
