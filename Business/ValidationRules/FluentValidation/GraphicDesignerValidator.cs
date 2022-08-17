namespace Business.ValidationRules.FluentValidation
{
    public class GraphicDesignerValidator : AbstractValidator<GraphicDesigner>
    {
        public GraphicDesignerValidator()
        {
            RuleFor(g => g.Name).NotEmpty().NotNull().WithMessage(GraphicDesignerConstants.GraphicDesignNameNull);
            RuleFor(g => g.Name).MinimumLength(3).WithMessage(GraphicDesignerConstants.GraphicDesignNameNull);
            RuleFor(g => g.SurName).NotEmpty().NotNull().WithMessage(GraphicDesignerConstants.GraphicDesignSurNameNull);
        }
    }
}
