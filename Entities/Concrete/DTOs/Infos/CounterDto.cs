using Core.Entities.Abstract;

namespace Entities.Concrete.DTOs.Infos
{
    public class CounterDto : IDto
    {
        public Guid Id { get; set; }

        public ulong Count { get; set; }
    }
}
