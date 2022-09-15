namespace Business.ValidationRules.FluentValidation
{
    public class LibraryValidator : AbstractValidator<Library>
    {       // todo look at later
        public LibraryValidator()
        {
            RuleFor(l => l.Name).NotEmpty().NotNull().WithMessage(LibraryConstants.NameNull);
            RuleFor(l => l.LibraryType).NotEmpty().NotNull().WithMessage(LibraryConstants.LibraryTypeNull);
        }
    }
}
