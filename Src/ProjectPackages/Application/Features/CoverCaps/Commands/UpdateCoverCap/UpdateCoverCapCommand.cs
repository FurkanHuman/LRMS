// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.CoverCaps.Commands.UpdateCoverCap;

public class UpdateCoverCapCommand : IRequest<UpdatedCoverCapResponse>, ISecuredRequest
{
    public byte Id { get; set; }
    public string Name { get; set; }

    public string[] Roles =>new[] {""};
}
