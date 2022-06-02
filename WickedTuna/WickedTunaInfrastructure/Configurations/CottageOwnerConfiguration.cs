using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class CottageOwnerConfiguration : IEntityTypeConfiguration<CottageOwner>
    {
        public void Configure(EntityTypeBuilder<CottageOwner> builder)
        {
            builder.ToTable("CottageOwners");
            builder.HasKey(u => u.UserId);
        }
    }
}
