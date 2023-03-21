// this file was created automatically.
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Infos;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CoverCaps.Queries.GetListByCoverCap;

public class GetListByCoverCapQueryHandler : IRequestHandler<GetListByCoverCapQuery, GetListResponse<GetListByCoverCapResponse>>
{
    private readonly ICoverCapRepository _covercapRepository;
    private readonly IMapper _mapper;

    public GetListByCoverCapQueryHandler(ICoverCapRepository covercapRepository, IMapper mapper)
    {
        _covercapRepository = covercapRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByCoverCapResponse>> Handle(GetListByCoverCapQuery request, CancellationToken cancellationToken)
    {
        IPaginate<CoverCap> covercaps = await _covercapRepository.GetListAsync(index: request.PageRequest.Page,
                                                                               size: request.PageRequest.PageSize,
                                                                               cancellationToken: cancellationToken);

        GetListResponse<GetListByCoverCapResponse> mappedGetListResponse = _mapper.Map<GetListResponse<GetListByCoverCapResponse>>(covercaps);
        return mappedGetListResponse;
    }
}
