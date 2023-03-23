// this file was created automatically.
using Application.Features.Cities.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, GetByIdCityResponse>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly CityBusinessRules _cityBusinessRules;

    public GetByIdCityQueryHandler(ICityRepository cityRepository, CityBusinessRules cityBusinessRules, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _cityBusinessRules = cityBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdCityResponse> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
    {
        _cityBusinessRules.IdIsExit(new() { Id = request.Id });

        City? city = await _cityRepository.GetAsync(predicate: c => c.Id == request.Id,
                                                    include: c => c.Include(c => c.Country),
                                                    cancellationToken: cancellationToken);

        GetByIdCityResponse cityListModelResponse = _mapper.Map<GetByIdCityResponse>(city);
        return cityListModelResponse;
    }
}
