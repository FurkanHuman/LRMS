using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CoverCapValidator : AbstractValidator<CoverCap>
    {
        public CoverCapValidator()
        {
            RuleFor(cc => cc.BookSkinType).NotEmpty().NotNull().WithMessage(CoverCapConstants.CoverCapNameNull);
            RuleFor(cc => cc.BookSkinType).MinimumLength(2).WithMessage(CoverCapConstants.KeywordNumberCounter);
        }
    }
}
