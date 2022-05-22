using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Country).NotEmpty().NotNull().WithMessage(CountryConstants.CountryNameNull);
            RuleFor(a => a.City).NotEmpty().NotNull().WithMessage(CityConstants.CityNameNull);

            RuleFor(a => a.PostalCode).NotEmpty().NotNull().WithMessage(AddressConstants.PostalCodeNull);
            RuleFor(a => a.PostalCode).MinimumLength(3).MaximumLength(10).WithMessage(AddressConstants.PostalCodeLength);

            RuleFor(a => a.AddressLine1).NotNull().NotEmpty().WithMessage(AddressConstants.AddressLengthNull);
            RuleFor(a => a.AddressLine1).MinimumLength(5).MaximumLength(50).WithMessage(AddressConstants.AddressLength);

            RuleFor(a => a.AddressLine2).NotNull().NotEmpty().WithMessage(AddressConstants.AddressLengthNull);
            RuleFor(a => a.AddressLine2).MinimumLength(5).MaximumLength(50).WithMessage(AddressConstants.AddressLength);


        }
    }
}