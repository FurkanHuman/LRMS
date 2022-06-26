using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class DissertationValidator : MaterialBaseValidator<Dissertation>
    {
        public DissertationValidator()
        {
            RuleFor(d => d.UniversityId).NotNull().NotEmpty().WithMessage(DissertationConstans.UniversityIdRequired);
            RuleFor(d => d.ResearcherId).NotNull().NotEmpty().WithMessage(DissertationConstans.ResearcherIdRequired);
            RuleFor(d => d.Language).NotNull().NotEmpty().WithMessage(DissertationConstans.LanguageNull);
            RuleFor(d => d.City).NotNull().NotEmpty().WithMessage(DissertationConstans.CityNull);
            RuleFor(d => d.DateTimeYear).NotNull().NotEmpty().WithMessage(DissertationConstans.DateTimeYearNull);
            RuleFor(d => d.DissertationNumber).NotNull().NotEmpty().WithMessage(DissertationConstans.DissertationNumberNull);
            RuleFor(d => d.ApprovalStatus).NotNull().NotEmpty().WithMessage(DissertationConstans.ApprovalStatusNull);
        }
    }
}
