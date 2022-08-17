﻿namespace Business.ValidationRules.FluentValidation
{
    public class CartographicMaterialValidator : MaterialBaseValidator<CartographicMaterial>
    {
        public CartographicMaterialValidator()
        {
            RuleFor(i => i.ImageId).NotEmpty().NotNull().WithMessage(CartographicMaterialConstants.ImageIdRequired);
            RuleFor(i => i.Date).NotNull().NotEmpty().WithMessage(CartographicMaterialConstants.DateRequared);
        }
    }
}
