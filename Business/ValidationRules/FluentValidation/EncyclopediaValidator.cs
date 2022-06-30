using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class EncyclopediaValidator : BasePaperValidator<Encyclopedia>
    {
        public EncyclopediaValidator()
        {
            RuleFor(ep => ep.SequenceNumber).NotNull().NotEmpty().WithMessage(EncyclopediaConstants.SequenceNumberNull);
        }
    }
}
