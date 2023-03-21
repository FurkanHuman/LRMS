// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CoverCaps.Queries.GetListByCoverCap;

public class GetListByCoverCapQuery : IRequest<GetListResponse<GetListByCoverCapResponse>>
{
    public PageRequest PageRequest { get; set; }
}
