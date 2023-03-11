// this file was created automatically.
using Domain.Entities.Infos;
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class AcademicJournalConfiguration : IEntityTypeConfiguration<AcademicJournal>
{
    public void Configure(EntityTypeBuilder<AcademicJournal> builder)
    {
        builder.HasKey(A => A.Id);
        builder.Property(A => A.Id);
        builder.Property(A => A.Name).IsRequired();

        builder.Property(A => A.Title).IsRequired();
        builder.Property(A => A.Description).IsRequired();
        builder.Property(A => A.CategoryId).IsRequired();


        builder.Property(A => A.TechnicalPlaceholdersId).IsRequired();
        builder.Property(A => A.StockId).IsRequired();
        builder.Property(A => A.CounterId).IsRequired();        
        builder.Property(A => A.DimensionsId);
        builder.Property(A => A.EMaterialFilesId);
        builder.Property(A => A.Price);
        builder.Property(A => A.State).IsRequired();
        builder.Property(A => A.SecretLevel);

        builder.Property(A => A.ResearcherId).IsRequired();
        builder.Property(A => A.EditorId).IsRequired();
        builder.Property(A => A.PublisherId).IsRequired();
        builder.Property(A => A.ReferenceId).IsRequired();
        builder.Property(A => A.DateOfYear).IsRequired();
        builder.Property(A => A.Volume).IsRequired();
        builder.Property(A => A.AJNumber).IsRequired();
        builder.Property(A => A.StartPageNumber).IsRequired();
        builder.Property(A => A.EndPageNumber).IsRequired();

        builder.Property(A => A.CreatedDate);
        builder.Property(A => A.UpdatedDate);
        builder.Property(A => A.IsDeleted);

        builder.HasOne(A => A.Stock);
        builder.HasOne(A => A.Counter);
        
        builder.HasMany(A => A.Categories);
        builder.HasMany(A => A.Dimensions);
        builder.HasMany(A => A.EMaterialFiles);
        builder.HasMany(A => A.TechnicalPlaceholders);

        builder.HasMany(A => A.Researchers);
        builder.HasMany(A => A.Editors);
        builder.HasMany(A => A.Publishers);
        builder.HasMany(A => A.References);
        builder.HasMany(A => A.Kits);
    }
}