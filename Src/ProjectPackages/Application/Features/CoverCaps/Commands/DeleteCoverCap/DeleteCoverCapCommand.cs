// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.CoverCaps.Commands.DeleteCoverCap;

public class DeleteCoverCapCommand : IRequest<DeletedCoverCapResponse>, ISecuredRequest
{
    public byte Id { get; set; }
    public string[] Roles =>new[] {""};
}
