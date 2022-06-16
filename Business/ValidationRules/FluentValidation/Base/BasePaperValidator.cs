using Business.Constants.Base;
using Core.Entities.Abstract;
using Entities.Concrete.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Base
{
    public class BasePaperValidator<T> : MaterialBaseValidator<T> where T : BasePaper, IEntity, new()
    {
        public BasePaperValidator()
        {
            RuleFor(bp => bp.CoverCapId).NotEmpty().NotNull().WithMessage(BaseConstants.CoverCapIdRequired);
            RuleFor(bp => bp.CoverImageId).NotEmpty().NotNull().WithMessage(BaseConstants.CoverImageIdRequired);
            RuleFor(bp => bp.WriterId).NotEmpty().NotNull().WithMessage(BaseConstants.WriterIdRequired);
            RuleFor(bp => bp.EditorId).NotEmpty().NotNull().WithMessage(BaseConstants.EditorIdRequired);
            RuleFor(bp => bp.TechnicalNumberId).NotEmpty().NotNull().WithMessage(BaseConstants.TechnicalNumberIdRequired);
            RuleFor(bp => bp.EditionId).NotEmpty().NotNull().WithMessage(BaseConstants.EditionIdRequired);
        }
    }
}
