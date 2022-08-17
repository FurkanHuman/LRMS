namespace Business.ValidationRules.FluentValidation
{
    public class MicroformValidator : MaterialBaseValidator<Microform>
    {
        public MicroformValidator()
        {
            RuleFor(m => m.Scale).NotEmpty().NotNull().WithMessage(MicroformConstants.ScaleISNull);
        }
    }
}
