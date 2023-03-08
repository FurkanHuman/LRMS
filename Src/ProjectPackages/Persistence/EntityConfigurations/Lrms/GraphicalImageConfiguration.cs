// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class GraphicalImageConfiguration : IEntityTypeConfiguration<GraphicalImage>
{
    public void Configure(EntityTypeBuilder<GraphicalImage> builder)
    {
        builder.HasKey(G => G.Id);

    }
}