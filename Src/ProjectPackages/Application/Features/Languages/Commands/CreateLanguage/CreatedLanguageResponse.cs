// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreatedLanguageResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set;}
}
