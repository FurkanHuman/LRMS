// this file was created automatically.
using FluentValidation;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(64);
    }
}
