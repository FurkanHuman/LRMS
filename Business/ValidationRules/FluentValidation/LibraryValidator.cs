using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(l => l.LibraryName).NotEmpty().NotNull().WithMessage(LibraryConstants.NameNull);
            RuleFor(l => l.Address).NotEmpty().NotNull().WithMessage(LibraryConstants.addressNull);
            RuleFor(l => l.LibraryType).NotEmpty().NotNull().WithMessage(LibraryConstants.LibraryTypeNull);
            RuleFor(l => l.Communication).NotEmpty().NotNull().WithMessage(LibraryConstants.CommunicationNull);


        }
    }
}
