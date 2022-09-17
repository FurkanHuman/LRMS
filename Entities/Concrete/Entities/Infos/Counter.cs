namespace Entities.Concrete.Entities.Infos
{
    public class Counter : BaseEntity<Guid>, IEntity
    {
        public ulong Count { get; set; }
    }
}
