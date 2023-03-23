// this file was created automatically.
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponse>
{
    public int Id { get; set; }
}
