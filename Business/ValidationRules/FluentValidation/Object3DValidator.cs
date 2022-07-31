
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
    public class Object3DValidator:MaterialBaseValidator<Object3D>
    {
        public Object3DValidator()
        {
            RuleFor(o => o.Owner).NotEmpty().NotNull().WithMessage(Object3DConstants.OtherPeopleIdRequired);
            RuleFor(o => o.ImageId).NotEmpty().NotNull().WithMessage(Object3DConstants.ImageIdRequired);
        }
    }
}
