namespace Entities.Concrete.DTOs.Gets.Infos
{
    public class ConsultantDto : FirstPagePersonBaseDto, IDto
    {
        public string? NamePreAttachment { get; set; }
    }
}