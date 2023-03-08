// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class ComposerConfiguration : IEntityTypeConfiguration<Composer>
{
    public void Configure(EntityTypeBuilder<Composer> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.SurName).IsRequired();
        builder.Property(C => C.NamePreAttachment);
        
        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);

        builder.Ignore(C => C.CreatedDate);

        builder.HasMany(C => C.MusicalNotes);
    }
}