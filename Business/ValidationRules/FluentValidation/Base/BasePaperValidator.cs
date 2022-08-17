namespace Business.ValidationRules.FluentValidation.Base
{
    public class BasePaperValidator<T> : MaterialBaseValidator<T> where T : BasePaper, IEntity, new()
    {
        public BasePaperValidator()
        {
            RuleFor(bp => bp.CoverCapId).NotEmpty().NotNull().WithMessage(BaseConstants.CoverCapIdRequired);
            RuleFor(bp => bp.ImageId).NotEmpty().NotNull().WithMessage(BaseConstants.CoverImageIdRequired);
            RuleFor(bp => bp.WriterId).NotEmpty().NotNull().WithMessage(BaseConstants.WriterIdRequired);
            RuleFor(bp => bp.EditorId).NotEmpty().NotNull().WithMessage(BaseConstants.EditorIdRequired);
            RuleFor(bp => bp.TechnicalNumberId).NotEmpty().NotNull().WithMessage(BaseConstants.TechnicalNumberIdRequired);
            RuleFor(bp => bp.EditionId).NotEmpty().NotNull().WithMessage(BaseConstants.EditionIdRequired);
        }
    }
}
