// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountries;

public class CreateCountriesCommandHandler : IRequestHandler<CreateCountriesCommand, CreatedCountriesResponse>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly CountryBusinessRules _countryBusinessRules;

    public CreateCountriesCommandHandler(ICountryRepository countryRepository, IMapper mapper,
                                        CountryBusinessRules countryBusinessRules)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<CreatedCountriesResponse> Handle(CreateCountriesCommand request, CancellationToken cancellationToken)
    {
        IList<Country> mappedCountries = _mapper.Map<IList<Country>>(request.CreateCountriesCommands);

        _countryBusinessRules.MultiExistByCountries(mappedCountries);

        IList<Country> createdCountries = await _countryRepository.AddRangeAsync(mappedCountries);

        IList<CreatedCountriesResponseHeader> responseHeaders = _mapper.Map<IList<CreatedCountriesResponseHeader>>(createdCountries);
        CreatedCountriesResponse createdCountryResponses = new() { CreatedCountries = responseHeaders };
        return createdCountryResponses;
    }
}