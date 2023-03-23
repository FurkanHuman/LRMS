// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetListByCity;

public class GetListByCityQueryHandler : IRequestHandler<GetListByCityQuery, GetListResponse<GetListByCityResponse>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetListByCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCityResponse>> Handle(GetListByCityQuery request, CancellationToken cancellationToken)
    {
        IPaginate<City> cities = await _cityRepository.GetListAsync(index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize,
                                                                    include: c => c.Include(c => c.Country),
                                                                    orderBy: c => c.OrderBy(c => !c.IsDeleted).OrderBy(c => c.Country.CountryCode),
                                                                    cancellationToken: cancellationToken);

        GetListResponse<GetListByCityResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCityResponse>>(cities);
        return mappedGetListResponse;
    }
}
