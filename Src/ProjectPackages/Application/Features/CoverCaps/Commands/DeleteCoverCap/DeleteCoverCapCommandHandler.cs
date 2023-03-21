// this file was created automatically.
using Application.Features.CoverCaps.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;

namespace Application.Features.CoverCaps.Commands.DeleteCoverCap;
 
public class DeleteCoverCapCommandHandler : IRequestHandler<DeleteCoverCapCommand, DeletedCoverCapResponse>
{
    private readonly ICoverCapRepository _covercapRepository;
    private readonly IMapper _mapper;
    private readonly CoverCapBusinessRules _covercapBusinessRules;

    public DeleteCoverCapCommandHandler(ICoverCapRepository covercapRepository, IMapper mapper,
                                        CoverCapBusinessRules covercapBusinessRules)
    {
        _covercapRepository = covercapRepository;
        _mapper = mapper;
        _covercapBusinessRules = covercapBusinessRules;
    }

    public async Task<DeletedCoverCapResponse> Handle(DeleteCoverCapCommand request, CancellationToken cancellationToken)
    {
        CoverCap mappedCoverCap = _mapper.Map<CoverCap>(request);

        _covercapBusinessRules.IdIsExit(mappedCoverCap);

        CoverCap deletedCoverCap = await _covercapRepository.DeleteAsync(mappedCoverCap);

        DeletedCoverCapResponse deletedCoverCapResponse = _mapper.Map<DeletedCoverCapResponse>(deletedCoverCap);
        return deletedCoverCapResponse;
    }
}
