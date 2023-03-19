// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Countries.Queries.GetListByCountry;

public class GetListByCountryQuery : IRequest<GetListResponse<GetListByCountryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
