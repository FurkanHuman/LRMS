namespace Entities.Concrete.Entities.Bases
{
    public class BaseEntity<I> where I : struct
    {
        [Key]
        public I Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
