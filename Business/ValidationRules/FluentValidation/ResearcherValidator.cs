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
    public class ResearcherValidator:AbstractValidator<Researcher>
    {
        public ResearcherValidator()
        {
            RuleFor(d => d.Name).NotEmpty().NotNull().WithMessage(ResearcherConstants.NameNull);
            RuleFor(d => d.Name).MinimumLength(2).WithMessage(ResearcherConstants.ResearcherLengthNotEnough);
            RuleFor(d => d.SurName).NotEmpty().NotNull().WithMessage(ResearcherConstants.SurNameNull);
            RuleFor(d => d.Specialty).NotEmpty().NotNull().WithMessage(ResearcherConstants.SpecialtyNull);
            RuleFor(d => d.Specialty).MinimumLength(2).WithMessage(ResearcherConstants.ResearcherLengthNotEnough);
        }
    }
}
