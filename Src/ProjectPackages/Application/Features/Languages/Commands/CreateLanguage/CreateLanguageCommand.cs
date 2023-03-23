// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { "" };
}
