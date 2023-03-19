// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdatedCountryResponse>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly CountryBusinessRules _countryBusinessRules;

    public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper,
                                        CountryBusinessRules countryBusinessRules)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<UpdatedCountryResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        _countryBusinessRules.IdIsExit(request.Id);

        Country getedCountry = _countryRepository.Get(c => c.Id == request.Id);

        _countryBusinessRules.NameIsExit(getedCountry);
        _countryBusinessRules.CountryCodeIsExit(getedCountry);

        getedCountry.Name = request.NewName;
        getedCountry.CountryCode = request.NewCountryCode;

        Country createdCountry = await _countryRepository.UpdateAsync(getedCountry);
        UpdatedCountryResponse createdCountryResponse = _mapper.Map<UpdatedCountryResponse>(createdCountry);
        return createdCountryResponse;
    }
}
