using Core.Entities.Abstract;

namespace Entities.Concrete.DTOs.Infos
{
    public class CoverCapDto : IDto
    {
        public byte Id { get; set; }

        public string BookSkinType { get; set; }
    }
}
