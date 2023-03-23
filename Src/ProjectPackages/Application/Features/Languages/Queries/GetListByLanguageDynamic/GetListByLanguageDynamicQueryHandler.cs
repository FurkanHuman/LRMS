// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetListByLanguageDynamic;

public class GetListByLanguageDynamicQueryHandler : IRequestHandler<GetListByLanguageDynamicQuery, GetListResponse<GetListByLanguageDynamicQueryResponse>>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetListByLanguageDynamicQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByLanguageDynamicQueryResponse>> Handle(GetListByLanguageDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Language> languages = await _languageRepository.GetListByDynamicAsync(
                                                                                                                  dynamic: request.DynamicQuery,
                                                                                                                  index: request.PageRequest.Page,
                                                                                                                  size: request.PageRequest.PageSize,
                                                                                                                  cancellationToken: cancellationToken);

        GetListResponse<GetListByLanguageDynamicQueryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByLanguageDynamicQueryResponse>>(languages);
        return mappedGetListResponse;
    }
}
