using Core.Entities.Abstract;
using Entities.Concrete.DTOs.Bases;

namespace Entities.Concrete.DTOs.Infos
{
    public class ComposerDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}
