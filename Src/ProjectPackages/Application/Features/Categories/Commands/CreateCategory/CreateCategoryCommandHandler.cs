// this file was created automatically.
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;
 
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                        CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category mappedCategory = _mapper.Map<Category>(request);

        _categoryBusinessRules.NameIsExit(mappedCategory);

        Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
        CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
        return createdCategoryResponse;
    }
}
