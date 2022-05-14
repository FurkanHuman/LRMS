﻿using Entities.Concrete;
using Entities.Concrete.Infos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class PostgreDbContext : DbContext
    {
        // Todo Can Maping

        public PostgreDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // I know Todo
            optionsBuilder.UseNpgsql("Host=localhost,Database=LRMS_DataBase;Username=postgres;Password=12345");
        }
        // entity Frontend
        public DbSet<CoverCap> BookCovers { get; set; }
        public DbSet<Category> BookCategories { get; set; }
        public DbSet<Image> BookCoverImages { get; set; }

        // entity Backend
        public DbSet<Editor> BookEditors { get; set; }
        public DbSet<TechnicalNumber> BookTechnicalNumbers { get; set; }
        public DbSet<Writer> BookWriters { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<GraphicDirector> GraphicDirectors { get; set; }
        public DbSet<GraphicDesign> GraphicDesign { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Interpreters> Interpreters { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Redaction> Redactions { get; set; }

        // entity full
        public DbSet<Book> Books { get; set; }
        public DbSet<Encyclopedia> Encyclopedias { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<NewsPaper> NewsPapers { get; set; }

    }
}
