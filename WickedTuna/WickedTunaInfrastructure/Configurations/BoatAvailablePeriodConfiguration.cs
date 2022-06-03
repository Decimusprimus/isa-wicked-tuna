using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Boats;

namespace WickedTunaInfrastructure.Configurations
{
    public class BoatAvailablePeriodConfiguration : IEntityTypeConfiguration<BoatAvailablePeriod>
    {
        public void Configure(EntityTypeBuilder<BoatAvailablePeriod> builder)
        {
            builder.HasOne(bap => bap.Boat)
                .WithMany(b => b.BoatAvailablePeriods)
                .HasForeignKey(bap => bap.BoatId);
        }
    }
}
