using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class DimensionValidator : AbstractValidator<Dimension>
    {
        public DimensionValidator()
        {
            RuleFor(d => d.Name).NotNull().NotEmpty().WithMessage(DimensionConstants.NameRequired);
            RuleFor(d => d.Name).Length(2, 25).WithMessage(DimensionConstants.NameLengthError);
            RuleFor(d => d.Width).NotNull().NotEmpty().WithMessage(DimensionConstants.WidthNull);
            RuleFor(d => d.Length).NotNull().NotEmpty().WithMessage(DimensionConstants.LengthNull);
            RuleFor(d => d.Height).Null().NotEmpty().WithMessage(DimensionConstants.HeightNull);
        }
    }
}
