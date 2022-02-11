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
    public class LibraryValidator:AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(l => l.Name).NotEmpty().NotNull().WithMessage(LibraryConstants.NameNull);
            RuleFor(l => l.Address).NotEmpty().NotNull().WithMessage(LibraryConstants.addressNull);
            RuleFor(l => l.Address).MinimumLength(10).WithMessage(LibraryConstants.addressLengthLess);

        }
    }
}
