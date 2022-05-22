using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ClountryValidator : AbstractValidator<Country>
    {
        public ClountryValidator()
        {
            RuleFor(c => c.CountryName).NotNull().NotEmpty().WithMessage(CountryConstants.CountryNameNull);
            RuleFor(c => c.CountryName).MaximumLength(200).WithMessage(CountryConstants.CountryNameLong);
            RuleFor(c => c.CountryCode).NotNull().NotEmpty().WithMessage(CountryConstants.CountryCodeNull);
            RuleFor(c => c.CountryCode).MaximumLength(10).WithMessage(CountryConstants.CountryCodeLong);
            RuleFor(c => c.Cities).NotEmpty().NotNull().WithMessage(CountryConstants.CountryCityNull);
        }
    }
}
