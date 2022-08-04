using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

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
