﻿using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class OtherPeople : FirstPagePersonBase, IEntity
    {
        [Required]
        public string Title { get; set; }

        public string? NamePreAttachment { get; set; }

        public IList<Book> Books { get; set; }
        public IList<BookSeries> BookSeries { get; set; }
        public IList<Encyclopedia> Encyclopedias { get; set; }
        public IList<Magazine> Magazines { get; set; }
        public IList<NewsPaper> NewsPapers { get; set; }
    }
}
