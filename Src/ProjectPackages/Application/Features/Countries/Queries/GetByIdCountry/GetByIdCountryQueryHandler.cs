// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Countries.Queries.GetByIdCountry;

public class GetByIdCountryQueryHandler : IRequestHandler<GetByIdCountryQuery, GetByIdCountryResponse>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly CountryBusinessRules _countryBusinessRules;

    public GetByIdCountryQueryHandler(ICountryRepository countryRepository, CountryBusinessRules countryBusinessRules, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _countryBusinessRules = countryBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdCountryResponse> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
    {
        _countryBusinessRules.IdIsExit(request.Id);

        Country country = await _countryRepository.GetAsync(c => c.Id == request.Id);

        GetByIdCountryResponse countryListModelResponse = _mapper.Map<GetByIdCountryResponse>(country);
        return countryListModelResponse;
    }
}
