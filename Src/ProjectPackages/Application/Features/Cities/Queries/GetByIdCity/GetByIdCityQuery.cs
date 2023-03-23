// this file was created automatically.
using MediatR;

namespace Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQuery : IRequest<GetByIdCityResponse>
{
    public int Id { get; set; }
}
