// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetListByLanguageDynamic;

public class GetListByLanguageDynamicQuery : IRequest<GetListResponse<GetListByLanguageDynamicQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
}
