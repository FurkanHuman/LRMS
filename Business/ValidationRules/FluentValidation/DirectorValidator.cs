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
    public class DirectorValidator:AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(DirectorConstants.DirectorNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(DirectorConstants.DirectorNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(DirectorConstants.DirectorSurnameNull);
        }
    }
}
