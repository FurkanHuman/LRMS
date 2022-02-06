using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GraphicDesignValidator : AbstractValidator<GraphicDesign>
    {
        public GraphicDesignValidator()
        {
            RuleFor(g => g.Name).NotEmpty().NotNull().WithMessage(GraphicDesignConstants.GraphicDesignNameNull);
            RuleFor(g => g.Name).MinimumLength(3).WithMessage(GraphicDesignConstants.GraphicDesignNameNull);
            RuleFor(g => g.SurName).NotEmpty().NotNull().WithMessage(GraphicDesignConstants.GraphicDesignSurNameNull);
        }
    }
}
