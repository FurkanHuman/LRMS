// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class TechnicalPlaceholderConfiguration : IEntityTypeConfiguration<TechnicalPlaceholder>
{
    public void Configure(EntityTypeBuilder<TechnicalPlaceholder> builder)
    {
        builder.HasKey(T => T.Id);

    }
}