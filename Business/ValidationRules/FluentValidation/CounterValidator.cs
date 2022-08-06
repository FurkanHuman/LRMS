using Business.Constants;
using Entities.Concrete.Infos;

namespace Business.ValidationRules.FluentValidation
{
    public class CounterValidator : AbstractValidator<Counter>
    {
        public CounterValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage(CounterConstants.CounterIdRequired);
            RuleFor(c => c.Count).NotEmpty().NotNull().WithMessage(CounterConstants.CountNull);
        }
    }
}
