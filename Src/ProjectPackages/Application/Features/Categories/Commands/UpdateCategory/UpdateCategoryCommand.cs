// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles =>new[] {""};
}
