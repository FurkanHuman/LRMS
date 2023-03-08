// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CartographicMaterialConfiguration : IEntityTypeConfiguration<CartographicMaterial>
{
    public void Configure(EntityTypeBuilder<CartographicMaterial> builder)
    {
        builder.HasKey(C => C.Id);

    }
}