// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class PosterConfiguration : IEntityTypeConfiguration<Poster>
{
    public void Configure(EntityTypeBuilder<Poster> builder)
    {
        builder.HasKey(P => P.Id);

    }
}