﻿using Business.Constants;
using Entities.Concrete.Infos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class InterpretersValidator: AbstractValidator<Interpreters>
    {
        public InterpretersValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(InterpretersConstants.InterpretersNameNull);
            RuleFor(x => x.Name).MinimumLength(3).WithMessage(InterpretersConstants.InterpretersNameLengthNotEnough);
            RuleFor(x => x.SurName).NotEmpty().NotNull().WithMessage(InterpretersConstants.InterpretersSurNameNull);
            RuleFor(x => x.WhichToLanguage).NotEmpty().NotNull().WithMessage(InterpretersConstants.InterpretersNull);
            RuleFor(x => x.WhichToLanguage).MinimumLength(3).WithMessage(InterpretersConstants.InterpretersNameLengthNotEnough);
        }
    }
}
