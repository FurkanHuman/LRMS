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
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.Name).NotEmpty().NotNull().WithMessage(WriterConstants.WriterNameNull);
            RuleFor(w => w.Name).MinimumLength(3).WithMessage(WriterConstants.WriterNameLengthNotEnough);
            RuleFor(w=>w.SurName).NotEmpty().NotNull().WithMessage(WriterConstants.WriterSurnameNull);
        }
    }
}
