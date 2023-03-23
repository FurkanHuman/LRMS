// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles =>new[] {""};
}
