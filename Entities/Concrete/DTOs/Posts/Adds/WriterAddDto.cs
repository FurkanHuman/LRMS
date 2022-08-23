namespace Entities.Concrete.DTOs.Posts.Adds
{
    public class WriterAddDto : IAddDto
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string? NamePreAttachment { get; set; }
    }
}
