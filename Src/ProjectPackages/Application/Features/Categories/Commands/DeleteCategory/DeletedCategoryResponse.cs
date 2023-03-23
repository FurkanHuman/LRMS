// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeletedCategoryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}
