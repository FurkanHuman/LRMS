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
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor<string>(c => c.CityName).NotNull().NotEmpty().WithMessage(CityConstants.CityNameNull);
            RuleFor<bool>(c => c.IsDeleted).NotEqual(true).WithMessage(CityConstants.CityAddedNotDeleted);
        }
    }
}
