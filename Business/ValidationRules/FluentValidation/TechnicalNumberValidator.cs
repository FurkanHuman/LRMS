namespace Business.Concrete
{
    public class TechnicalNumberValidator : AbstractValidator<TechnicalNumber>
    {
        public TechnicalNumberValidator()
        {
            RuleFor(t => t.Barcode).NotEmpty().NotNull().WithMessage(TechnicalNumberConstants.BarcodeNull);
            RuleFor(t => t.ISBN).NotEmpty().NotNull().WithMessage(TechnicalNumberConstants.ISBNNumberEmpty);
        }
    }
}