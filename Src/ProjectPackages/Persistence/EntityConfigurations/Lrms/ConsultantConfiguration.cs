// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ConsultantConfiguration : IEntityTypeConfiguration<Consultant>
{
    public void Configure(EntityTypeBuilder<Consultant> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.SurName).IsRequired();
        builder.Property(C => C.NamePreAttachment).IsRequired();

        builder.Property(C => C.CreatedDate);
        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);

        builder.HasMany(C => C.Theses);
    }
}