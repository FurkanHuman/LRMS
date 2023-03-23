// this file was created automatically.
using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;
 
public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageResponse>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
                                        LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<UpdatedLanguageResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        Language mappedLanguage = _mapper.Map<Language>(request);

        _languageBusinessRules.IdIsExit(mappedLanguage);
        _languageBusinessRules.NameIsExit(mappedLanguage);

        Language updatedLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
        UpdatedLanguageResponse updatedLanguageResponse = _mapper.Map<UpdatedLanguageResponse>(updatedLanguage);
        return updatedLanguageResponse;
    }
}
