// this file was created automatically.
using Application.Features.CoverCaps.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.CoverCaps.Commands.CreateCoverCap;
 
public class CreateCoverCapCommandHandler : IRequestHandler<CreateCoverCapCommand, CreatedCoverCapResponse>
{
    private readonly ICoverCapRepository _covercapRepository;
    private readonly IMapper _mapper;
    private readonly CoverCapBusinessRules _covercapBusinessRules;

    public CreateCoverCapCommandHandler(ICoverCapRepository covercapRepository, IMapper mapper,
                                        CoverCapBusinessRules covercapBusinessRules)
    {
        _covercapRepository = covercapRepository;
        _mapper = mapper;
        _covercapBusinessRules = covercapBusinessRules;
    }

    public async Task<CreatedCoverCapResponse> Handle(CreateCoverCapCommand request, CancellationToken cancellationToken)
    {
        CoverCap mappedCoverCap = _mapper.Map<CoverCap>(request);

        _covercapBusinessRules.NameIsExit(mappedCoverCap);

        CoverCap createdCoverCap = await _covercapRepository.AddAsync(mappedCoverCap);
        
        CreatedCoverCapResponse createdCoverCapResponse = _mapper.Map<CreatedCoverCapResponse>(createdCoverCap);
        return createdCoverCapResponse;
    }
}
