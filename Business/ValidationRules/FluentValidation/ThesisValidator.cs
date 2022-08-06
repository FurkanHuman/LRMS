using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ThesisValidator : MaterialBaseValidator<Thesis>
    {
        public ThesisValidator()
        {
            RuleFor(t => t.UniversityId).NotEmpty().NotNull().WithMessage(ThesisConstants.UniversityIdRequired);
            RuleFor(t => t.ResearcherId).NotEmpty().NotNull().WithMessage(ThesisConstants.ResearcherIdRequired);
            RuleFor(t => t.ConsultantId).NotEmpty().NotNull().WithMessage(ThesisConstants.ConsultantIdRequired);
            RuleFor(t => t.ThesisDegree).NotEmpty().NotNull().WithMessage(ThesisConstants.ThesisDegreeRequired);
            RuleFor(t => t.City.Id).NotEmpty().NotNull().WithMessage(ThesisConstants.CityIdRequired);
            RuleFor(t => t.DateTimeYear).NotEmpty().NotNull().LessThanOrEqualTo((ushort)DateTime.Now.Year).WithMessage(ThesisConstants.DateTimeError);
            RuleFor(t => t.Language.Id).NotEmpty().NotNull().WithMessage(ThesisConstants.LanguageIdRequired);
            RuleFor(t => t.ThesisNumber).NotEmpty().NotNull().WithMessage(ThesisConstants.ThesisNumberRequired);
            RuleFor(t => t.PermissionStatus).NotEmpty().NotNull().WithMessage(ThesisConstants.PermissionStatusRequired);
            RuleFor(t => t.ApprovalStatus).NotEmpty().NotNull().WithMessage(ThesisConstants.ApprovalStatusRequired);
        }
    }
}
