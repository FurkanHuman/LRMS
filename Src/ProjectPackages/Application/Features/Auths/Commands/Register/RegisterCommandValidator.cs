using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.UserForRegisterDto.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(c => c.UserForRegisterDto.LastName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(c => c.UserForRegisterDto.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(c => c.UserForRegisterDto.Password).NotNull().NotEmpty().MinimumLength(4);
        }
    }
}
