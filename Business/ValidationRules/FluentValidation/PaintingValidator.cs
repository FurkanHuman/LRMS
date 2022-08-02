﻿using Business.Constants;
using Business.ValidationRules.FluentValidation.Base;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class PaintingValidator : MaterialBaseValidator<Painting>
    {
        public PaintingValidator()
        {
            RuleFor(p => p.Owner).NotEmpty().NotNull().WithMessage(PaintingConstants.OtherPeopleIdRequired);
            RuleFor(p => p.ImageId).NotEmpty().NotNull().WithMessage(PaintingConstants.ImageIdRequired);
        }
    }
}