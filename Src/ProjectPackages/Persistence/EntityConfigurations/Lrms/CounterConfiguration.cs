// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CounterConfiguration : IEntityTypeConfiguration<Counter>
{
    public void Configure(EntityTypeBuilder<Counter> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.Count).IsRequired();

        builder.Property(C => C.CreatedDate);
        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);
    }
}