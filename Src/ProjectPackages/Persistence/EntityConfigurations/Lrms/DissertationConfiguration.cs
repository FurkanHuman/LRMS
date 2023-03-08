// this file was created automatically.
using Domain.Entities.Mains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class DissertationConfiguration : IEntityTypeConfiguration<Dissertation>
{
    public void Configure(EntityTypeBuilder<Dissertation> builder)
    {
        builder.HasKey(D => D.Id);

    }
}