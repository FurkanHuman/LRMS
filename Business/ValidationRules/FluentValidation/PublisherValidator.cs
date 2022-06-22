using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherNameNotNull);
            RuleFor(p => p.Address).NotEmpty().NotNull().WithMessage(PublisherConstants.PublisherAddressNotNull);
            RuleFor(p => p.DateOfPublication).NotEmpty().NotNull().WithMessage(PublisherConstants.DateOfPublicationNull);
        }
    }
}
