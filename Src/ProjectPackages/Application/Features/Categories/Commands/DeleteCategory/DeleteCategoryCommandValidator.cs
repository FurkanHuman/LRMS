// this file was created automatically.
using FluentValidation;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(c=>c.Id).NotEmpty().NotNull().GreaterThan(0);
    }
}
