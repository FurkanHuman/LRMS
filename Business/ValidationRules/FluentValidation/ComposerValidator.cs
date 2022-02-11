using Business.Constants;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ComposerValidator: AbstractValidator<Composer>
    {
        public ComposerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage(ComposerConstants.ComposerNameNull);
            RuleFor(c => c.Name).MinimumLength(3).WithMessage(ComposerConstants.ComposerNameLengthNotEnough);
            RuleFor(c => c.SurName).NotEmpty().NotNull().WithMessage(ComposerConstants.ComposerSurnameNull);
        }
    }
}
