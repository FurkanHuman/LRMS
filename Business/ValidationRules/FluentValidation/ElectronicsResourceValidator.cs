namespace Business.ValidationRules.FluentValidation
{
    public class ElectronicsResourceValidator : MaterialBaseValidator<ElectronicsResource>
    {
        public ElectronicsResourceValidator()
        {
            RuleFor(er => er.ResourceUrl).NotEmpty().NotNull().WithMessage(ElectronicsResourceConstants.ResourceUrlNull);
        }
    }
}
