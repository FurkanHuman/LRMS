// this file was created automatically.
using Application.Features.CoverCaps.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CoverCaps.Queries.GetByIdCoverCap;

public class GetByIdCoverCapQueryHandler : IRequestHandler<GetByIdCoverCapQuery, GetByIdCoverCapResponse>
{
    private readonly ICoverCapRepository _covercapRepository;
    private readonly IMapper _mapper;
    private readonly CoverCapBusinessRules _covercapBusinessRules;

    public GetByIdCoverCapQueryHandler(ICoverCapRepository covercapRepository, CoverCapBusinessRules covercapBusinessRules, IMapper mapper)
    {
        _covercapRepository = covercapRepository;
        _covercapBusinessRules = covercapBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdCoverCapResponse> Handle(GetByIdCoverCapQuery request, CancellationToken cancellationToken)
    {
        _covercapBusinessRules.IdIsExit(new() { Id = request.Id });

        CoverCap? covercap = await _covercapRepository.GetAsync(c =>
                                                               c.Id == request.Id,
                                                      //include: c => c.Include(c => c.Books)
                                                      //               .Include(c => c.BookSeries)
                                                      //               .Include(c => c.Encyclopedias)
                                                      //               .Include(c => c.Magazines)
                                                      //               .Include(c => c.NewsPapers),
                                                      cancellationToken: cancellationToken);

        GetByIdCoverCapResponse getByIdCoverCapResponse = _mapper.Map<GetByIdCoverCapResponse>(covercap);
        return getByIdCoverCapResponse;
    }
}
