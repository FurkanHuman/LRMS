// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.Cities.Commands.DeleteCity;

public class DeleteCityCommand : IRequest<DeletedCityResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles =>new[] {""};
}
