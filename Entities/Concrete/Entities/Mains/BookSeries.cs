﻿namespace Entities.Concrete.Entities.Mains
{
    public class BookSeries : BasePaper, IEntity
    {
        [Required]
        public Guid BooksIds { get; set; }

        public IList<Book> Books { get; set; }
        public IList<Kit> Kits { get; set; }
    }
}
