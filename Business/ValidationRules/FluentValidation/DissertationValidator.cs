using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class DissertationValidator : MaterialBaseValidator<Dissertation>
    {
        public DissertationValidator()
        {
            RuleFor(d => d.UniversityId).NotNull().NotEmpty().WithMessage(DissertationConstants.UniversityIdRequired);
            RuleFor(d => d.ResearcherId).NotNull().NotEmpty().WithMessage(DissertationConstants.ResearcherIdRequired);
            RuleFor(d => d.Language).NotNull().NotEmpty().WithMessage(DissertationConstants.LanguageNull);
            RuleFor(d => d.City).NotNull().NotEmpty().WithMessage(DissertationConstants.CityNull);
            RuleFor(d => d.DateTimeYear).NotNull().NotEmpty().WithMessage(DissertationConstants.DateTimeYearNull);
            RuleFor(d => d.DissertationNumber).NotNull().NotEmpty().WithMessage(DissertationConstants.DissertationNumberNull);
            RuleFor(d => d.ApprovalStatus).NotNull().NotEmpty().WithMessage(DissertationConstants.ApprovalStatusNull);
        }
    }
}
