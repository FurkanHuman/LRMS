using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class GraphicDirectorValidator:AbstractValidator<GraphicDirector>
    {
        public GraphicDirectorValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(GraphicDirectorConstants.GraphicDirectorNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(GraphicDirectorConstants.GraphicDirectorNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(GraphicDirectorConstants.GraphicDirectorSurnameNull);
        }
    }
}
