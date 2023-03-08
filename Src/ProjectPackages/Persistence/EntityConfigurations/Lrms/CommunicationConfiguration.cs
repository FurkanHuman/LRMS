// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class CommunicationConfiguration : IEntityTypeConfiguration<Communication>
{
    public void Configure(EntityTypeBuilder<Communication> builder)
    {
        builder.HasKey(C => C.Id);
        builder.Property(C => C.Id);
        builder.Property(C => C.Name).IsRequired();
        builder.Property(C => C.FaxNumber);
        builder.Property(C => C.Email).IsRequired();
        builder.Property(C => C.WebSite).IsRequired();

        builder.Property(C => C.UpdatedDate);
        builder.Property(C => C.IsDeleted);
        
        builder.Ignore(C => C.CreatedDate);
    }
}