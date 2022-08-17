namespace Business.ValidationRules.FluentValidation
{
    public class EditionValidator : AbstractValidator<Edition>
    {
        public EditionValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage(EditionConstants.EditionNameNotNull);
            RuleFor(e => e.Publisher.Address).NotEmpty().NotNull().WithMessage(EditionConstants.EditionAddressNotNull);
            RuleFor(e => e.Publisher.DateOfPublication).NotEmpty().NotNull().WithMessage(EditionConstants.DateOfPublicationNull);
            RuleFor(e => e.EditionNumber).NotEmpty().NotNull().WithMessage(EditionConstants.EditionNameNotNull);
        }
    }
}
