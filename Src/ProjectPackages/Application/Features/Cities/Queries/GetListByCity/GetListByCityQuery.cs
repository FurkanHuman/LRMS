// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Cities.Queries.GetListByCity;

public class GetListByCityQuery : IRequest<GetListResponse<GetListByCityResponse>>
{
    public PageRequest PageRequest { get; set; }
}
