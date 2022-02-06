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
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().NotNull().WithMessage(CategoryConstants.CategoryNameNull);
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage(CategoryConstants.CategroNamelength);
        }
    }
}
