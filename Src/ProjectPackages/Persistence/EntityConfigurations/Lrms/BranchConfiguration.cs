// this file was created automatically.
using Domain.Entities.Infos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Lrms;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(B => B.Id);
        builder.Property(B => B.Id).UseIdentityColumn();
        builder.Property(B => B.Name).IsRequired();
        
        builder.Property(B => B.UpdatedDate);
        builder.Property(B => B.IsDeleted);

        builder.Ignore(B => B.CreatedDate);
        

    }
}