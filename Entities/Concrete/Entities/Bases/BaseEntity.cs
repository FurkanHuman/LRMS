namespace Entities.Concrete.Entities.Bases
{
    public class BaseEntity<I> where I : struct
    {        
        public I Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
