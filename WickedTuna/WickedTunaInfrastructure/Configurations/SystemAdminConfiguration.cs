using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Auth;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class SystemAdminConfiguration : IEntityTypeConfiguration<SystemAdmin>
    {
        public void Configure(EntityTypeBuilder<SystemAdmin> builder)
        {
            builder.ToTable("SystemAdmins");
            builder.HasKey(u => u.UserId);
           // builder.HasOne<ApplicationUser>(au => au.ApplicationUser)
           //     .WithOne(a => a.SystemAdmin)
            //    .HasForeignKey<ApplicationUser>(au => au.Id);
        }
    }
}
