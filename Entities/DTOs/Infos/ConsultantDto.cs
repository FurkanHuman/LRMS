using Core.Entities.Abstract;
using Entities.DTOs.Base;

namespace Entities.DTOs.Infos
{
    public class ConsultantDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}