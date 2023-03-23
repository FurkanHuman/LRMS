// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Categories.Queries.GetListByCategory;

public class GetListByCategoryQueryHandler : IRequestHandler<GetListByCategoryQuery, GetListResponse<GetListByCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetListByCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCategoryResponse>> Handle(GetListByCategoryQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Category> categories = await _categoryRepository.GetListAsync(predicate: c => !c.IsDeleted,
                                                                                index: request.PageRequest.Page,
                                                                                size: request.PageRequest.PageSize,
                                                                                cancellationToken: cancellationToken);

        GetListResponse<GetListByCategoryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCategoryResponse>>(categories);
        return mappedGetListResponse;
    }
}
