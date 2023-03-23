// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Categories.Queries.GetListByCategory;

public class GetListByCategoryQuery : IRequest<GetListResponse<GetListByCategoryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
