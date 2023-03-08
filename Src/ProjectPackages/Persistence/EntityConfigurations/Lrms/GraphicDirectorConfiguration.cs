// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class GraphicDirectorConfiguration : IEntityTypeConfiguration<GraphicDirector>
{
    public void Configure(EntityTypeBuilder<GraphicDirector> builder)
    {
        builder.HasKey(G => G.Id);

    }
}