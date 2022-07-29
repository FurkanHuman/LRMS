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
    public class NewsPaperValidator : MaterialBaseValidator<NewsPaper>
    {
        public NewsPaperValidator()
        {
            RuleFor(np=>np.NewsPaperName).NotEmpty().NotNull().WithMessage(NewsPaperConstants.NameRequired);
            RuleFor(np=>np.Number).NotEmpty().NotNull().WithMessage(NewsPaperConstants.NumberIsNull);
            RuleFor(np => np.ImageId).NotEmpty().NotNull().WithMessage(NewsPaperConstants.ImageIdRequired);
            RuleFor(np => np.Date).NotEmpty().NotNull().WithMessage(NewsPaperConstants.DateRequired);
            RuleFor(np => np.IsDestroyed).NotEmpty().NotNull().WithMessage(NewsPaperConstants.IsDestroyerd);
        }
    }
}
