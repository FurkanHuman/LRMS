// this file was created automatically.
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { "" };
}
