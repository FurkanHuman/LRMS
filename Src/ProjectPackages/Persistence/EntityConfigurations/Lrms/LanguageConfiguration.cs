// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(L => L.Id);
        builder.Property(L => L.Id).UseIdentityColumn();
        builder.Property(L => L.Name).IsRequired();

        builder.Ignore(L => L.CreatedDate);
        builder.Ignore(L => L.UpdatedDate);
        builder.Ignore(L => L.IsDeleted);
    }
}