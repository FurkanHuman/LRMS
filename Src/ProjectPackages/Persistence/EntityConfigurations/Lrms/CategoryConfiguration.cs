// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(C => C.Id);

        builder.Property(C => C.Id).UseIdentityColumn();
        builder.Property(C => C.Name).IsRequired();

        builder.Property(C => C.IsDeleted);
         
        builder.Ignore(C => C.CreatedDate);
        builder.Ignore(C => C.UpdatedDate);

        builder.HasMany(C => C.AcademicJournals);
        builder.HasMany(C => C.AudioRecords);
        builder.HasMany(C => C.Books);
        builder.HasMany(C => C.BookSeries);
        builder.HasMany(C => C.CartographicMaterials);
        builder.HasMany(C => C.Depictions);
        builder.HasMany(C => C.Dissertations);
        builder.HasMany(C => C.ElectronicsResources);
        builder.HasMany(C => C.Encyclopedias);
        builder.HasMany(C => C.GraphicalImages);
        builder.HasMany(C => C.Kits);
        builder.HasMany(C => C.Magazines);
        builder.HasMany(C => C.Microforms);
        builder.HasMany(C => C.MusicalNotes);
        builder.HasMany(C => C.NewsPapers);
        builder.HasMany(C => C.Object3Ds);
        builder.HasMany(C => C.Paintings);
        builder.HasMany(C => C.Posters);
        builder.HasMany(C => C.Theses);
    }
}