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

    }
}