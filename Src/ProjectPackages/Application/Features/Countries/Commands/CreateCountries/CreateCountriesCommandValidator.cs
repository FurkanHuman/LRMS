// this file was created automatically.
using FluentValidation;

namespace Application.Features.Countries.Commands.CreateCountries;

public class CreateCountriesCommandValidator : AbstractValidator<CreateCountriesCommand>
{
    public CreateCountriesCommandValidator()
    {
        RuleFor(c => c.CreateCountriesCommands).NotNull().NotEmpty();
        RuleFor(c => c.CreateCountriesCommands.Select(c => c.Name)).NotNull().NotEmpty().ForEach(c => c.NotNull().NotEmpty());
        RuleFor(c => c.CreateCountriesCommands.Select(c => c.CountryCode)).NotNull().NotEmpty().ForEach(c => c.Length(3).NotNull().NotEmpty());      
    }
}
