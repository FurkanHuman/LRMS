// this file was created automatically.
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetListByLanguage;

public class GetListByLanguageQuery : IRequest<GetListResponse<GetListByLanguageResponse>>
{
    public PageRequest PageRequest { get; set; }
}
