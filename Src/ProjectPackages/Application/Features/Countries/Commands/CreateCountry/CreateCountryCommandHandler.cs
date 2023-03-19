// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreatedCountryResponse>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly CountryBusinessRules _countryBusinessRules;

    public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper,
                                        CountryBusinessRules countryBusinessRules)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<CreatedCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        Country mappedCountry = _mapper.Map<Country>(request);

        mappedCountry.CountryCode = mappedCountry.CountryCode.ToUpper();

        _countryBusinessRules.NameIsExit(mappedCountry);
        _countryBusinessRules.CountryCodeIsExit(mappedCountry);

        Country createdCountry = await _countryRepository.AddAsync(mappedCountry);
        CreatedCountryResponse createdCountryResponse = _mapper.Map<CreatedCountryResponse>(createdCountry);
        return createdCountryResponse;
    }
}
