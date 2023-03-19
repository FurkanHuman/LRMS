// this file was created automatically.
using Application.Features.Countries.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.Countries.Commands.DeleteCountry;
 
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeletedCountryResponse>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    private readonly CountryBusinessRules _countryBusinessRules;

    public DeleteCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper,
                                        CountryBusinessRules countryBusinessRules)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _countryBusinessRules = countryBusinessRules;
    }

    public async Task<DeletedCountryResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        _countryBusinessRules.IdIsExit(request.Id);

        Country mappedCountry = _mapper.Map<Country>(request);

        Country deletedCountry = await _countryRepository.DeleteAsync(mappedCountry);
        DeletedCountryResponse deletedCountryResponse = _mapper.Map<DeletedCountryResponse>(deletedCountry);
        return deletedCountryResponse;
    }
}
