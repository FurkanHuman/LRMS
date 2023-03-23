// this file was created automatically.
using Application.Repositories;
using Application.Features.Languages.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Languages.Rules;

public class LanguageBusinessRules : BaseBusinessRules
{

    private readonly ILanguageRepository _languageRepository;

    public LanguageBusinessRules(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    internal void IdIsExit(Language language)
    {
        bool result = _languageRepository.Any(l => l.Id == language.Id);
        if (!result)
            throw new BusinessException(LanguageMessages.IdIsExit);
    }

    internal void NameIsExit(Language language)
    {
        bool result = _languageRepository.Any(l => l.Name == language.Name);
        if (result)
            throw new BusinessException(LanguageMessages.NameIsExit);
    }
}
