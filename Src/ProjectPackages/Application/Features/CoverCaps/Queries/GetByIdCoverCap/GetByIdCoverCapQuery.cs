// this file was created automatically.
using MediatR;

namespace Application.Features.CoverCaps.Queries.GetByIdCoverCap;

public class GetByIdCoverCapQuery : IRequest<GetByIdCoverCapResponse>
{
    public byte Id { get; set; }
}
