// this file was created automatically.
using MediatR;

namespace Application.Features.Countries.Queries.GetByIdCountry;

public class GetByIdCountryQuery : IRequest<GetByIdCountryResponse>
{
    public int Id { get; set; }
}
