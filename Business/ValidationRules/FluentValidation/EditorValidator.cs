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
    public class EditorValidator:AbstractValidator<Editor>
    {
        public EditorValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(EditorConstants.EditorNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(EditorConstants.EditorNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(EditorConstants.EditorSurnameNull);
        }
    }
}
