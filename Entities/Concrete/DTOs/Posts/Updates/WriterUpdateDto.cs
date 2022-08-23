using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.Posts.Updates
{
    public class WriterUpdateDto : IUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string? NamePreAttachment { get; set; }

        public bool IsDeleted { get; set; }

        public Guid[]? BookGuids { get; set; }
        public Guid[]? BookSerieGuids { get; set; }
        public Guid[]? EncyclopediaGuids { get; set; }
        public Guid[]? MagazineGuids { get; set; }
        public Guid[]? NewsPaperGuids { get; set; }
    }
}
