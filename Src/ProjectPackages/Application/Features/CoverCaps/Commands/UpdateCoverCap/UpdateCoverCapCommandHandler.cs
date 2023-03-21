// this file was created automatically.
using Application.Features.CoverCaps.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.CoverCaps.Commands.UpdateCoverCap;
 
public class UpdateCoverCapCommandHandler : IRequestHandler<UpdateCoverCapCommand, UpdatedCoverCapResponse>
{
    private readonly ICoverCapRepository _covercapRepository;
    private readonly IMapper _mapper;
    private readonly CoverCapBusinessRules _covercapBusinessRules;

    public UpdateCoverCapCommandHandler(ICoverCapRepository covercapRepository, IMapper mapper,
                                        CoverCapBusinessRules covercapBusinessRules)
    {
        _covercapRepository = covercapRepository;
        _mapper = mapper;
        _covercapBusinessRules = covercapBusinessRules;
    }

    public async Task<UpdatedCoverCapResponse> Handle(UpdateCoverCapCommand request, CancellationToken cancellationToken)
    {
        CoverCap mappedCoverCap = _mapper.Map<CoverCap>(request);

        _covercapBusinessRules.IdIsExit(mappedCoverCap);
        _covercapBusinessRules.NameIsExit(mappedCoverCap);

        CoverCap updatedCoverCap = await _covercapRepository.UpdateAsync(mappedCoverCap);

        UpdatedCoverCapResponse updatedCoverCapResponse = _mapper.Map<UpdatedCoverCapResponse>(updatedCoverCap);
        return updatedCoverCapResponse;
    }
}
