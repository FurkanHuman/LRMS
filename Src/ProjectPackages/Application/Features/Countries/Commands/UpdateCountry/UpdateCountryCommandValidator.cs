// this file was created automatically.
using FluentValidation;

namespace Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0).NotEmpty().NotNull();
        RuleFor(c => c.NewCountryCode).Length(3).NotEmpty().NotNull();
        RuleFor(c => c.NewName).NotEmpty().NotNull();
    }
}
