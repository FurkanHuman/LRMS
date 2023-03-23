// this file was created automatically.
using Application.Features.Cities.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Cities.Commands.DeleteCity;
 
public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeletedCityResponse>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly CityBusinessRules _cityBusinessRules;

    public DeleteCityCommandHandler(ICityRepository cityRepository, IMapper mapper,
                                        CityBusinessRules cityBusinessRules)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _cityBusinessRules = cityBusinessRules;
    }

    public async Task<DeletedCityResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        City mappedCity = _mapper.Map<City>(request);

        _cityBusinessRules.IdIsExit(mappedCity);

        City deletedCity = await _cityRepository.DeleteAsync(mappedCity);
        DeletedCityResponse deletedCityResponse = _mapper.Map<DeletedCityResponse>(deletedCity);
        return deletedCityResponse;
    }
}
