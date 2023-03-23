// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Categories.Queries.GetListByCategoryDynamic;

public class GetListByCategoryDynamicQuery : IRequest<GetListResponse<GetListByCategoryDynamicQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
}
