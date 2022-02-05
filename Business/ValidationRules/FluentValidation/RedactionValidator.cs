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
    public class RedactionValidator: AbstractValidator<Redaction>
    {
        public RedactionValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(RedactionConstants.RedactionNameNull);
            RuleFor(r => r.Name).MinimumLength(3).WithMessage(RedactionConstants.RedactionNameLengthNotEnough);
            RuleFor(r => r.SurName).NotEmpty().NotNull().WithMessage(RedactionConstants.RedactionSurnameNull);
        }
    }
}
