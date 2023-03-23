// this file was created automatically.
using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage;

public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageResponse>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _languageBusinessRules = languageBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdLanguageResponse> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
    {
        _languageBusinessRules.IdIsExit(new() { Id = request.Id });

        Language? language = await _languageRepository.GetAsync(l => l.Id == request.Id);

        GetByIdLanguageResponse languageListModelResponse = _mapper.Map<GetByIdLanguageResponse>(language);
        return languageListModelResponse;
    }
}
