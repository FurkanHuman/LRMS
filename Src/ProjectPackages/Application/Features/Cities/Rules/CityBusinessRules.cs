// this file was created automatically.
using Application.Repositories;
using Application.Features.Cities.Constants;
using Core.Application.Rules;
using Domain.Entities.Infos;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Cities.Rules;

public class CityBusinessRules : BaseBusinessRules
{

    private readonly ICityRepository _cityRepository;

    public CityBusinessRules(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    internal void IdIsExit(City city)
    {
        bool result = _cityRepository.Any(c => c.Id == city.Id);
        if (!result)
            throw new BusinessException(CityMessages.IdIsExit);
    }

    internal void NameIsExit(City city)
    {
       bool result = _cityRepository.Any(c => c.Name == city.Name);
        if (result)
            throw new BusinessException(CityMessages.NameIsExit);
    }
}
