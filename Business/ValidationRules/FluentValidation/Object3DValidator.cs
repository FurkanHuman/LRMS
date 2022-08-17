namespace Business.ValidationRules.FluentValidation
{
    public class Object3DValidator : MaterialBaseValidator<Object3D>
    {
        public Object3DValidator()
        {
            RuleFor(o => o.Owner).NotEmpty().NotNull().WithMessage(Object3DConstants.OtherPeopleIdRequired);
            RuleFor(o => o.ImageId).NotEmpty().NotNull().WithMessage(Object3DConstants.ImageIdRequired);
        }
    }
}
