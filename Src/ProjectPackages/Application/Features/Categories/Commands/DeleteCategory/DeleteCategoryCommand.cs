// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

using Core.Application.Pipelines.Authorization;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles =>new[] {""};
}
