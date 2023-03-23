// this file was created automatically.
using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;
 
public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageResponse>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper,
                                        LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<DeletedLanguageResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        Language mappedLanguage = _mapper.Map<Language>(request);

        _languageBusinessRules.IdIsExit(mappedLanguage);

        Language deletedLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
        DeletedLanguageResponse deletedLanguageResponse = _mapper.Map<DeletedLanguageResponse>(deletedLanguage);
        return deletedLanguageResponse;
    }
}
