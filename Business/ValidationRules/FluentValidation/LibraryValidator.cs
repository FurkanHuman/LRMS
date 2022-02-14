using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(l => l.Name).NotEmpty().NotNull().WithMessage(LibraryConstants.NameNull);
            RuleFor(l => l.Address).NotEmpty().NotNull().WithMessage(LibraryConstants.addressNull);
            RuleFor(l => l.Address).MinimumLength(10).WithMessage(LibraryConstants.addressLengthLess);

        }
    }
}
