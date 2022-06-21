using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;
using Business.Constants;

namespace Business.ValidationRules.FluentValidation
{
    public class BookSeriesValidator : BasePaperValidator<BookSeries>
    {
        public BookSeriesValidator()
        {
            RuleFor(bs => bs.BookIds).NotNull().NotEmpty().WithMessage(CartographicMaterialConstants.BookSeriesIdRequired);
        }
    }
}
