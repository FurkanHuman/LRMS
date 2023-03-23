// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdatedCategoryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
