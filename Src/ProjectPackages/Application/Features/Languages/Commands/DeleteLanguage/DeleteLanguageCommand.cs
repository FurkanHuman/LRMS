// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles =>new[] {""};
}
