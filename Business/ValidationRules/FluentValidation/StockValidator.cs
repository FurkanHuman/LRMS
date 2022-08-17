namespace Business.ValidationRules.FluentValidation
{
    public class StockValidator : AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(s => s.Library.Id).NotEmpty().NotNull().WithMessage(StockConstans.LibraryIdNull);
            RuleFor(s => s.StockCode).NotEmpty().NotNull().WithMessage(StockConstans.StockCodeNull);
            RuleFor(s => s.Quantity).NotEmpty().NotNull().WithMessage(StockConstans.QuantityNull);
        }
    }
}
