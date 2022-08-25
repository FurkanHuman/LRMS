namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class ComposerUpdateDto : IUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string? NamePreAttachment { get; set; }

        public bool IsDeleted { get; set; }
    }
}
