namespace Entities.Concrete.Entities.Infos
{
    public class Language : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
