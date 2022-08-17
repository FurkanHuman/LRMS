using Core.Entities.Abstract;
using Entities.Concrete.DTOs.Bases;

namespace Entities.Concrete.DTOs.Infos
{
    public class ConsultantDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}