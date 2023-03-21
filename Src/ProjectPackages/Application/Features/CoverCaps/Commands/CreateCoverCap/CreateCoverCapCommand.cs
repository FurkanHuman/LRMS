// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.CoverCaps.Commands.CreateCoverCap;

public class CreateCoverCapCommand : IRequest<CreatedCoverCapResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { "" };
}
