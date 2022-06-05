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
    public class BoatReservationOptionsConfiguration : IEntityTypeConfiguration<BoatReservationOptions>
    {
        public void Configure(EntityTypeBuilder<BoatReservationOptions> builder)
        {
            builder.HasOne(bro => bro.BoatReservation)
                .WithMany(br => br.BoatReservationOptions)
                .HasForeignKey(bro => bro.BoatReservationId);
        }
    }
}
