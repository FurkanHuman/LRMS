// this file was created automatically.
using FluentValidation;

namespace Application.Features.Cities.Commands.DeleteCity;

public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
{
    public DeleteCityCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}
