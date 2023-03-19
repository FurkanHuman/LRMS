using FluentValidation;

namespace Application.Features.Countries.Queries.GetByIdCountry;

internal class GetByIdCountryQueryValidator:AbstractValidator<GetByIdCountryQuery> 
{
    public GetByIdCountryQueryValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);        
    }
}
