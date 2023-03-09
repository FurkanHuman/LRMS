// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class OtherPeopleConfiguration : IEntityTypeConfiguration<OtherPeople>
{
    public void Configure(EntityTypeBuilder<OtherPeople> builder)
    {
        builder.HasKey(O => O.Id);
        builder.Property(O => O.Name).IsRequired();
        builder.Property(O => O.SurName).IsRequired();
        builder.Property(O => O.Title).IsRequired();
        builder.Property(O => O.NamePreAttachment);
        
        builder.Property(O => O.UpdatedDate);
        builder.Property(O => O.IsDeleted);

        builder.Ignore(O => O.CreatedDate);

        builder.HasMany(O => O.Books);
        builder.HasMany(O => O.BookSeries);
        builder.HasMany(O => O.Encyclopedias);
        builder.HasMany(O => O.Magazines);
        builder.HasMany(O => O.NewsPapers);
    }
}