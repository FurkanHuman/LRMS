// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountries;

public class CreateCountriesCommand : IRequest<CreatedCountriesResponse>, ISecuredRequest
{
    public IList<CreateCountriesCommandHeader> CreateCountriesCommands { get; set; }
    public string[] Roles => new[] { "Admin" };
}
