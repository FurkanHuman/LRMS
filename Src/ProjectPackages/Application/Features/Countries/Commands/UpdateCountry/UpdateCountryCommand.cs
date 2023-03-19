// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest<UpdatedCountryResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string NewName { get; set; }
    public string NewCountryCode { get; set; }
    public string[] Roles =>new[] {""};
}
