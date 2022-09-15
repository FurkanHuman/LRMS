namespace Entities.Concrete.Entities.Bases
{
    public class FirstPagePersonBase : BaseEntity<Guid>
    {
        [Required]
        public string SurName { get; set; }
    }
}
