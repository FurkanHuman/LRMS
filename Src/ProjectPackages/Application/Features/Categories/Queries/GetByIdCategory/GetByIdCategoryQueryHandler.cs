// this file was created automatically.
using Application.Features.Categories.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _categoryBusinessRules = categoryBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        _categoryBusinessRules.IdIsExit(new() { Id = request.Id });

        Category? category = await _categoryRepository.GetAsync(c => c.Id == request.Id);

        GetByIdCategoryResponse categoryListModelResponse = _mapper.Map<GetByIdCategoryResponse>(category);
        return categoryListModelResponse;
    }
}
