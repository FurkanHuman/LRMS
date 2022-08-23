namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class BranchUpdateDto : IUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
