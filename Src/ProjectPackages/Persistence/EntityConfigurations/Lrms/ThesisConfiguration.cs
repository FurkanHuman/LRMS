// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ThesisConfiguration : IEntityTypeConfiguration<Thesis>
{
    public void Configure(EntityTypeBuilder<Thesis> builder)
    {
        builder.HasKey(T => T.Id);
        builder.Property(T => T.Id);
        builder.Property(T => T.Name).IsRequired();

        builder.Property(T => T.Title).IsRequired();
        builder.Property(T => T.Description).IsRequired();
        builder.Property(T => T.CategoryId).IsRequired();

        builder.Property(T => T.UniversityId).IsRequired();
        builder.Property(T => T.ThesisDegree).IsRequired();
        builder.Property(T => T.ResearcherId).IsRequired();
        builder.Property(T => T.ConsultantId).IsRequired();
        builder.Property(T => T.CityId).IsRequired();
        builder.Property(T => T.DateTimeYear).IsRequired();
        builder.Property(T => T.LanguageId).IsRequired();
        builder.Property(T => T.ThesisNumber).IsRequired();
        builder.Property(T => T.PermissionStatus).IsRequired();
        builder.Property(T => T.ApprovalStatus).IsRequired();

        builder.Property(T => T.TechnicalPlaceholdersId).IsRequired();
        builder.Property(T => T.StockId).IsRequired();
        builder.Property(T => T.CounterId).IsRequired();
        builder.Property(T => T.DimensionsId);
        builder.Property(T => T.EMaterialFilesId);
        builder.Property(T => T.Price);
        builder.Property(T => T.State).IsRequired();
        builder.Property(T => T.SecretLevel);

        builder.Property(T => T.CreatedDate);
        builder.Property(T => T.UpdatedDate);
        builder.Property(T => T.IsDeleted);


        builder.HasOne(T => T.University);
        builder.HasOne(T => T.Consultant);
        builder.HasOne(T => T.Language);
        builder.HasOne(T => T.City);
        builder.HasOne(T => T.Researcher);

        builder.HasOne(T => T.Stock);
        builder.HasOne(T => T.Counter);

        builder.HasMany(P => P.Kits);

        builder.HasMany(T => T.Categories);
        builder.HasMany(T => T.Dimensions);
        builder.HasMany(T => T.EMaterialFiles);
        builder.HasMany(T => T.TechnicalPlaceholders);
    }
}