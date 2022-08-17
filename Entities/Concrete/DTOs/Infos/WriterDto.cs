using Core.Entities.Abstract;
using Entities.Concrete.DTOs.Bases;

namespace Entities.Concrete.DTOs.Infos
{
    public class WriterDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}
