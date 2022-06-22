using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : BasePaperValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.OriginalBookName).Length(2, 128).WithMessage(BookConstants.BookNameCharactersBetwen);
            RuleFor(b => b.ReferenceId).NotEmpty().NotNull().WithMessage(BookConstants.ReferenceIdRequired);
        }
    }
}
