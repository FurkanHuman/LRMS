// this file was created automatically.
using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(64);
    }
}
