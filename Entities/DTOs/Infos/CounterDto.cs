using Core.Entities.Abstract;

namespace Entities.DTOs.Infos
{
    public class CounterDto : IDto
    {
        public Guid Id { get; set; }

        public ulong Count { get; set; }
    }
}
