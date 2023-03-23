// this file was created automatically.
using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage;
 
public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
                                        LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        Language mappedLanguage = _mapper.Map<Language>(request);

        _languageBusinessRules.NameIsExit(mappedLanguage);

        Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
        CreatedLanguageResponse createdLanguageResponse = _mapper.Map<CreatedLanguageResponse>(createdLanguage);
        return createdLanguageResponse;
    }
}
