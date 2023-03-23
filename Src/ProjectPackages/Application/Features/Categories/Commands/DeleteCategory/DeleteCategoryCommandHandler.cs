// this file was created automatically.
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory;
 
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                        CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category mappedCategory = _mapper.Map<Category>(request);

        _categoryBusinessRules.IdIsExit(mappedCategory);

        Category deletedCategory = await _categoryRepository.DeleteAsync(mappedCategory);
        DeletedCategoryResponse deletedCategoryResponse = _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        return deletedCategoryResponse;
    }
}
