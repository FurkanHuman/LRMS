// this file was created automatically.
using FluentValidation;

namespace Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
{
    public DeleteCountryCommandValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0).NotEmpty().NotNull();
    }
}
