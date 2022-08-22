namespace Entities.Concrete.DTOs.Gets.Infos
{
    public class CounterDto : IDto
    {
        public Guid Id { get; set; }

        public ulong Count { get; set; }
    }
}
