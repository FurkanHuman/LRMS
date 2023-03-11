// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class KitConfiguration : IEntityTypeConfiguration<Kit>
{
    public void Configure(EntityTypeBuilder<Kit> builder)
    {
        builder.HasKey(K => K.Id);
        builder.Property(K => K.Id);
        builder.Property(K => K.Name).IsRequired();

        builder.Property(K => K.Title).IsRequired();
        builder.Property(K => K.Description).IsRequired();
        builder.Property(K => K.CategoryId).IsRequired();

        builder.Property(K => K.ImageId).IsRequired();

        builder.Property(K => K.AcademicJournalsId);
        builder.Property(K => K.AudioRecordsId);
        builder.Property(K => K.BooksId);
        builder.Property(K => K.BookSeriesId);
        builder.Property(K => K.CartographicMaterialsId);
        builder.Property(K => K.DepictionsId);
        builder.Property(K => K.DissertationsId);
        builder.Property(K => K.ElectronicsResourcesId);
        builder.Property(K => K.EncyclopediasId);
        builder.Property(K => K.GraphicalImagesId);
        builder.Property(K => K.MagazinesId);
        builder.Property(K => K.MicroformsId);
        builder.Property(K => K.MusicalNotesId);
        builder.Property(K => K.NewsPapersId);
        builder.Property(K => K.Object3DsId);
        builder.Property(K => K.PaintingsId);
        builder.Property(K => K.PostersId);
        builder.Property(K => K.ThesesId);

        builder.Property(K => K.IsKitBroken);

        builder.Property(K => K.TechnicalPlaceholdersId).IsRequired();
        builder.Property(K => K.StockId).IsRequired();
        builder.Property(K => K.CounterId).IsRequired();
        builder.Property(K => K.DimensionsId);
        builder.Property(K => K.EMaterialFilesId);
        builder.Property(K => K.Price);
        builder.Property(K => K.State).IsRequired();
        builder.Property(K => K.SecretLevel);

        builder.Property(K => K.CreatedDate);
        builder.Property(K => K.UpdatedDate);
        builder.Property(K => K.IsDeleted);

        builder.HasOne(K => K.Stock);
        builder.HasOne(K => K.Counter);

        builder.HasMany(K => K.Images);

        builder.HasMany(K => K.AcademicJournals);
        builder.HasMany(K => K.AudioRecords);
        builder.HasMany(K => K.Books);
        builder.HasMany(K => K.BookSeries);
        builder.HasMany(K => K.CartographicMaterials);
        builder.HasMany(K => K.Depictions);
        builder.HasMany(K => K.Dissertations);
        builder.HasMany(K => K.ElectronicsResources);
        builder.HasMany(K => K.Encyclopedias);
        builder.HasMany(K => K.GraphicalImages);
        builder.HasMany(K => K.Magazines);
        builder.HasMany(K => K.Microforms);
        builder.HasMany(K => K.MusicalNotes);
        builder.HasMany(K => K.NewsPapers);
        builder.HasMany(K => K.Object3Ds);
        builder.HasMany(K => K.Paintings);
        builder.HasMany(K => K.Posters);
        builder.HasMany(K => K.Theses);

        builder.HasMany(K => K.Categories);
        builder.HasMany(K => K.Dimensions);
        builder.HasMany(K => K.EMaterialFiles);
        builder.HasMany(K => K.TechnicalPlaceholders);
    }
}