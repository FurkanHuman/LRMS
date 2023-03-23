// this file was created automatically.
using FluentValidation;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(255);
        RuleFor(c => c.CountryId).NotEmpty().NotNull().GreaterThan(0);
    }
}
