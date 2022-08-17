namespace Business.ValidationRules.FluentValidation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.CountryName).NotNull().NotEmpty().WithMessage(CountryConstants.CountryNameNull);
            RuleFor(c => c.CountryName).MaximumLength(200).WithMessage(CountryConstants.CountryNameLong);
            RuleFor(c => c.CountryCode).NotNull().NotEmpty().WithMessage(CountryConstants.CountryCodeNull);
            RuleFor(c => c.CountryCode).MaximumLength(10).WithMessage(CountryConstants.CountryCodeLong);
        }
    }
}
