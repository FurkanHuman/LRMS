// this file was created automatically.
using Application.Repositories;
using Application.Features.Categories.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{

    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    internal void NameIsExit(Category category)
    {
        bool result = _categoryRepository.Any(p => p.Name == category.Name);
        if (!result)
            return;
        throw new BusinessException(CategoryMessages.NameIsExit);
    }

    internal void IdIsExit(Category category)
    {
        bool result = _categoryRepository.Any(p => p.Id == category.Id);
        if (result)
            return;
        throw new BusinessException(CategoryMessages.IdIsExit);
    }
}
