// this file was created automatically.
using FluentValidation;

namespace Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull();

        RuleFor(c => c.CountryCode).NotEmpty().NotNull().Length(3);
    }
}
