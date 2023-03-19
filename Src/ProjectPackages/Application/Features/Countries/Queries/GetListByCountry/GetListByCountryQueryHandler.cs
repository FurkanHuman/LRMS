// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Countries.Queries.GetListByCountry;

public class GetListByCountryQueryHandler : IRequestHandler<GetListByCountryQuery, GetListResponse<GetListByCountryResponse>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetListByCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCountryResponse>> Handle(GetListByCountryQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Country> countries = await _countryRepository.GetListAsync(index: request.PageRequest.Page,
                                                                             size: request.PageRequest.PageSize,
                                                                             include: c => c.Include(c => c.Cities),
                                                                             orderBy: c => c.OrderBy(c => c.CountryCode),
                                                                             cancellationToken: cancellationToken);

        GetListResponse<GetListByCountryResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCountryResponse>>(countries);
        return mappedGetListResponse;
    }
}
