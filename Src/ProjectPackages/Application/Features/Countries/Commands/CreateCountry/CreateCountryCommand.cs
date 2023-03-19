// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryCommand : IRequest<CreatedCountryResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string CountryCode { get; set; }

    public string[] Roles => new[] { "" };
}
