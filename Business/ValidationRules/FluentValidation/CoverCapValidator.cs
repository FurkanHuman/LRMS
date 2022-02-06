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
    public class CoverCapValidator : AbstractValidator<CoverCap>
    {
        public CoverCapValidator()
        {
            RuleFor(cc => cc.BookSkinType).NotEmpty().NotNull().WithMessage(CoverCapConstants.CoverCapNameNull);
            RuleFor(cc => cc.BookSkinType).MinimumLength(2).WithMessage(CoverCapConstants.KeywordNumberCounter);
        }
    }
}
