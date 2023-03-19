// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryCommand : IRequest<DeletedCountryResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles =>new[] {""};
}
