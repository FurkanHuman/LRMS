﻿using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Editor : FirstPagePersonBase, IEntity
{
    public IList<AcademicJournal> AcademicJournals { get; set; }
    public IList<Book> Books { get; set; }
    public IList<BookSeries> BookSeries { get; set; }
    public IList<Encyclopedia> Encyclopedias { get; set; }
    public IList<Magazine> Magazines { get; set; }
    public IList<NewsPaper> NewsPapers { get; set; }
}