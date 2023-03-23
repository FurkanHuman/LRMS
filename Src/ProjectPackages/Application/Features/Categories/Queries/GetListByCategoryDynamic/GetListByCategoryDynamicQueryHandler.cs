// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Categories.Queries.GetListByCategoryDynamic;

public class GetListByCategoryDynamicQueryHandler : IRequestHandler<GetListByCategoryDynamicQuery, GetListResponse<GetListByCategoryDynamicQueryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetListByCategoryDynamicQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCategoryDynamicQueryResponse>> Handle(GetListByCategoryDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Category> categories = await _categoryRepository.GetListByDynamicAsync(
                                                                                                                  dynamic: request.DynamicQuery,
                                                                                                                  index: request.PageRequest.Page,
                                                                                                                  size: request.PageRequest.PageSize,
                                                                                                                  cancellationToken: cancellationToken);

        GetListResponse<GetListByCategoryDynamicQueryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCategoryDynamicQueryResponse>>(categories);
        return mappedGetListResponse;
    }
}
