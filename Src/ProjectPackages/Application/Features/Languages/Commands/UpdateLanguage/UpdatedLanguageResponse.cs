// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdatedLanguageResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
