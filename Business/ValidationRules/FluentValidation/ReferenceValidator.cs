namespace Business.ValidationRules.FluentValidation
{
    public class ReferenceValidator : AbstractValidator<Reference>
    {
        public ReferenceValidator()
        {
            RuleFor(r => r.ReferenceDate).NotEmpty().NotNull().WithMessage(ReferenceConstants.DateNull);
            RuleFor(r => r.Owner).MinimumLength(3).NotEmpty().NotNull().WithMessage(ReferenceConstants.OwnerNull);
            RuleFor(r => r.StartPageNumber).NotNull().NotEmpty().WithMessage(ReferenceConstants.StartPageNumber);
            RuleFor(r => r.TechnicalNumber.Id).NotEmpty().NotNull().WithMessage(ReferenceConstants.TechNull);
        }
    }
}
