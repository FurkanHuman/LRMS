// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.Extensions.Primitives;
using Serilog.Sinks.PeriodicBatching;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreateCityCommand : IRequest<CreatedCityResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public int CountryId { get; set; }

    public string[] Roles => new[] { "" };
}
