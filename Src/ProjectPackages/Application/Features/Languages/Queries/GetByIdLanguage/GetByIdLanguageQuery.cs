// this file was created automatically.
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage;

public class GetByIdLanguageQuery : IRequest<GetByIdLanguageResponse>
{
    public int Id { get; set; }
}
