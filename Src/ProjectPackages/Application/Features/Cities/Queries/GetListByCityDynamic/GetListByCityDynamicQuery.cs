// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Cities.Queries.GetListByCityDynamic;

public class GetListByCityDynamicQuery : IRequest<GetListResponse<GetListByCityDynamicQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
}
