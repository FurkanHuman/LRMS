using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EditionValidator : AbstractValidator<Edition>
    {
        public EditionValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage(EditionConstants.EditionNameNotNull);
            RuleFor(e => e.Address).NotEmpty().NotNull().WithMessage(EditionConstants.EditionAddressNotNull);
            RuleFor(e => e.Address).MinimumLength(5).WithMessage(EditionConstants.AddressLengthLess);
            RuleFor(e => e.PhoneNumber).NotEmpty().NotNull().WithMessage(EditionConstants.EditionPhoneNotNull);
            RuleFor(e => e.DateOfPublication).NotEmpty().NotNull().WithMessage(EditionConstants.DateOfPublicationNull);
            RuleFor(e => e.WebSite).NotEmpty().NotNull().WithMessage(EditionConstants.EditionWebAddressNotNull);
            RuleFor(e => e.WebSite).MaximumLength(5).WithMessage(EditionConstants.AddressLengthLess);
            RuleFor(e => e.EditionNumber).NotEmpty().NotNull().WithMessage(EditionConstants.EditionNameNotNull);
        }
    }
}
