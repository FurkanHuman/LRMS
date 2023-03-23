// this file was created automatically.
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;
 
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                        CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category mappedCategory = _mapper.Map<Category>(request);

        _categoryBusinessRules.IdIsExit(mappedCategory);
        _categoryBusinessRules.NameIsExit(mappedCategory);

        Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
        UpdatedCategoryResponse updatedCategoryResponse = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        return updatedCategoryResponse;
    }
}
