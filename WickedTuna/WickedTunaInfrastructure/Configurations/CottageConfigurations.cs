using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Common;
using WickedTunaCore.Cottages;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class CottageConfigurations : IEntityTypeConfiguration<Cottage>
    {
        public void Configure(EntityTypeBuilder<Cottage> builder)
        {
            builder.OwnsOne(c => c.Address, add =>
            {
                add.Property(p => p.Street).HasColumnName(nameof(Address.Street));
                add.Property(p => p.City).HasColumnName(nameof(Address.City));
                add.Property(p => p.County).HasColumnName(nameof(Address.County));
            });
            builder.HasOne<CottageOwner>(c => c.CottageOwner)
                .WithMany(co => co.Cottages)
                .HasForeignKey(c => c.CottageOwnerId);
        }
    }
}
