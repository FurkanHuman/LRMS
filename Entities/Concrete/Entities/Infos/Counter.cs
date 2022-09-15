namespace Entities.Concrete.Entities.Infos
{
    public class Counter : BaseEntity<Guid>, IEntity
    {
        [Required]
        public ulong Count { get; set; }
    }
}
