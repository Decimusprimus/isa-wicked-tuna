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
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(u => u.Client)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<Client>(u => u.UserId);
            builder.HasOne(u => u.SystemAdmin)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<SystemAdmin>(u => u.UserId);
            builder.HasOne(u => u.BoatOwner)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<BoatOwner>(u => u.UserId);
            builder.HasOne(u => u.CottageOwner)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<CottageOwner>(u => u.UserId);
            builder.HasOne(u => u.Instructor)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<Instructor>(u => u.UserId);

        }
    }
}
