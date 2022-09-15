namespace Business.ValidationRules.FluentValidation
{
    public class CoverCapValidator : AbstractValidator<CoverCap>
    {
        public CoverCapValidator()
        {
            RuleFor(cc => cc.Name).NotEmpty().NotNull().WithMessage(CoverCapConstants.CoverCapNameNull);
            RuleFor(cc => cc.Name).MinimumLength(2).WithMessage(CoverCapConstants.KeywordNumberCounter);
        }
    }
}
