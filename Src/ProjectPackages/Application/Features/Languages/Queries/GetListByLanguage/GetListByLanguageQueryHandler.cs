// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetListByLanguage;

public class GetListByLanguageQueryHandler : IRequestHandler<GetListByLanguageQuery, GetListResponse<GetListByLanguageResponse>>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetListByLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByLanguageResponse>> Handle(GetListByLanguageQuery request, CancellationToken cancellationToken)
    {

        IPaginate<Language> languages = await _languageRepository.GetListAsync(
                                                                               orderBy: l => l.OrderBy(l => l.Name),
                                                                               index: request.PageRequest.Page,
                                                                               size: request.PageRequest.PageSize,
                                                                               cancellationToken: cancellationToken);

        GetListResponse<GetListByLanguageResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByLanguageResponse>>(languages);
        return mappedGetListResponse;
    }
}
