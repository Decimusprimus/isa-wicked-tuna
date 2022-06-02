using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class SystemAdminConfiguration : IEntityTypeConfiguration<SystemAdmin>
    {
        public void Configure(EntityTypeBuilder<SystemAdmin> builder)
        {
            builder.ToTable("SystemAdmins");
            builder.HasKey(u => u.UserId);
        }
    }
}
