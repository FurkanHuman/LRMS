using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class KitValidator: MaterialBaseValidator<Kit>
    {
        public KitValidator()
        {
            RuleFor(k => k.IsKitBroken).NotEmpty().NotNull().WithMessage(KitConstants.KitBrokenNull);
        }
    }
}
