using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherNameNotNull);
            RuleFor(p => p.Address).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherAddressNotNull);
            RuleFor(p => p.Address).MinimumLength(5).WithMessage(PublisherConstants.AddressLengthLess);
            RuleFor(p => p.PhoneNumber).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherPhoneNotNull);
            RuleFor(p => p.DateOfPublication).NotEmpty().NotNull().WithMessage(PublisherConstants.DateOfPublicationNull);
            RuleFor(p => p.WebSite).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherWebAddressNotNull);
            RuleFor(P => P.WebSite).MinimumLength(5).WithMessage(PublisherConstants.AddressLengthLess);
        }
    }
}
