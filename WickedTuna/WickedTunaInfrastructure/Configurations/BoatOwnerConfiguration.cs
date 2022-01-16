using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class BoatOwnerConfiguration : IEntityTypeConfiguration<BoatOwner>
    {
        public void Configure(EntityTypeBuilder<BoatOwner> builder)
        { 
            builder.ToTable("BoatOwners");
            builder.HasKey(bo => bo.UserId);
        }
    }
}
