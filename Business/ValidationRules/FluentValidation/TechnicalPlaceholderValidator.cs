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
    public class TechnicalPlaceholderValidator:AbstractValidator<TechnicalPlaceholder>
    {
        public TechnicalPlaceholderValidator()
        {
            RuleFor(t => t.StockNumber).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.StockNumberEmpty);
            RuleFor(t => t.WhereMaterial).NotNull().NotEmpty().WithMessage(TechnicalPlaceholderConstants.WhereMaterialEmpty);
        }
    }
}
