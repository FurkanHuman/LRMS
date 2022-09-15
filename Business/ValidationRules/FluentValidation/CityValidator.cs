namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor<string>(c => c.Name).NotNull().NotEmpty().WithMessage(CityConstants.CityNameNull);
            RuleFor<string>(c => c.Name).MaximumLength(200).WithMessage(CityConstants.CityNamelength);
            RuleFor<bool>(c => c.IsDeleted).NotEqual(true).WithMessage(CityConstants.CityAddedNotDeleted);
        }
    }
}
