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
    public class BoatReservationConfiguration : IEntityTypeConfiguration<BoatReservation>
    {
        public void Configure(EntityTypeBuilder<BoatReservation> builder)
        {
            builder.HasOne(br => br.Boat)
                .WithMany(b => b.BoatReservations)
                .HasForeignKey(br => br.BoatId);
            builder.HasOne(br => br.Client)
                .WithMany(c => c.BoatReservations)
                .HasForeignKey(br => br.ClientId);
        }
    }
}
