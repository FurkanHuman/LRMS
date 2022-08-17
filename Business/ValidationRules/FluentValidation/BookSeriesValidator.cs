namespace Business.ValidationRules.FluentValidation
{
    public class BookSeriesValidator : BasePaperValidator<BookSeries>
    {
        public BookSeriesValidator()
        {
            RuleFor(bs => bs.BooksIds).NotNull().NotEmpty().WithMessage(CartographicMaterialConstants.BookSeriesIdRequired);
        }
    }
}
