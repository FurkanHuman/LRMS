// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Cities.Commands.UpdateCity;

public class UpdateCityCommand : IRequest<UpdatedCityResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }

    public string[] Roles =>new[] {""};
}
