// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Cities.Queries.GetListByCityDynamic;

public class GetListByCityDynamicQueryHandler : IRequestHandler<GetListByCityDynamicQuery, GetListResponse<GetListByCityDynamicQueryResponse>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetListByCityDynamicQueryHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCityDynamicQueryResponse>> Handle(GetListByCityDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<City> cities = await _cityRepository.GetListByDynamicAsync(
                                                                                                                  dynamic: request.DynamicQuery,
                                                                                                                  index: request.PageRequest.Page,
                                                                                                                  size: request.PageRequest.PageSize,
                                                                                                                  cancellationToken: cancellationToken);

        GetListResponse<GetListByCityDynamicQueryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCityDynamicQueryResponse>>(cities);
        return mappedGetListResponse;
    }
}
