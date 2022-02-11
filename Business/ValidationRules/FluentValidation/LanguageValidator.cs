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
    public class LanguageValidator:AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(l=>l.LanguageName).NotEmpty().NotNull().WithMessage(LanguageConstants.LanguageNameNull);
        }
    }
}
