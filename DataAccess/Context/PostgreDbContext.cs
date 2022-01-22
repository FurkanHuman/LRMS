using Entities.Concrete.BookCover;
using Entities.Concrete.BookFirstPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext():base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost,Database=LRMS_DataBase;Username=postgres;Password=12345");
        }
        // Book Frontend
        public DbSet<BookCoverCap> BookCovers { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookCoverImage> BookCoverImages { get; set; }

        // Book Backend
        public DbSet<BookEditor> BookEditors { get; set; }
        public DbSet<BookTechnicalNumber> BookTechnicalNumbers { get; set; }
        public DbSet<BookWriter> BookWriters { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<GraphicDesignOrDirector> GraphicDesignOrDirectors { get; set; }
        public DbSet<Interpreters> Interpreters { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Redaction> Redactions { get; set; }
    }
}
