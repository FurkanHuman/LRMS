// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class TechnicalNumberConfiguration : IEntityTypeConfiguration<TechnicalNumber>
{
    public void Configure(EntityTypeBuilder<TechnicalNumber> builder)
    {
        builder.HasKey(T => T.Id);

    }
}