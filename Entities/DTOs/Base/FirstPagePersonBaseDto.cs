using Core.Entities.Abstract;

namespace Entities.DTOs.Base
{
    public class FirstPagePersonBaseDto : IDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
