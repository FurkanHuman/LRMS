﻿using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Edition : BaseEntity<Guid>, IEntity
{
    public Guid PublisherId { get; set; }

    public Publisher Publisher { get; set; }

    public int EditionNumber { get; set; }

    public IList<Book> Books { get; set; }
    public IList<BookSeries> BookSeries { get; set; }
    public IList<Encyclopedia> Encyclopedias { get; set; }
    public IList<Magazine> Magazines { get; set; }
    public IList<NewsPaper> NewsPapers { get; set; }
}