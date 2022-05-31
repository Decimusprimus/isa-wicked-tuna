using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Boats;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class BoatConfiguration : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.OwnsOne(b => b.Address, add =>
            {
                add.Property(p => p.Street).HasColumnName(nameof(Address.Street));
                add.Property(p => p.City).HasColumnName(nameof(Address.City));
                add.Property(p => p.County).HasColumnName(nameof(Address.County));
            });
            builder.HasOne<BoatOwner>(b => b.BoatOwner)
                .WithMany(bo => bo.Boats)
                .HasForeignKey(b => b.BoatOwnerId);
        }
    }
}
