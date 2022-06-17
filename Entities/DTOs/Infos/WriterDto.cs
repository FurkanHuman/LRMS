using Core.Entities.Abstract;
using Entities.DTOs.Base;

namespace Entities.DTOs.Infos
{
    public class WriterDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}
