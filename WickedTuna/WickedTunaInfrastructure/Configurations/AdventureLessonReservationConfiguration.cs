using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.AdventuresLessons;

namespace WickedTunaInfrastructure.Configurations
{
    public class AdventureLessonReservationConfiguration : IEntityTypeConfiguration<AdventureLessonReservation>
    {
        public void Configure(EntityTypeBuilder<AdventureLessonReservation> builder)
        {
            builder.HasOne(alr => alr.AdventureLesson)
                .WithMany(al => al.AdventureLessonReservations)
                .HasForeignKey(alr => alr.AdventureLessonId);
            builder.HasOne(alr => alr.Client)
                .WithMany(c => c.AdventureLessonReservations)
                .HasForeignKey(alr => alr.ClientId);
        }
    }
}
