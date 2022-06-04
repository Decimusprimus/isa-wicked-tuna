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
    public class InstructorAvailablePeriodConfiguration : IEntityTypeConfiguration<InstructorAvailablePeriod>
    {
        public void Configure(EntityTypeBuilder<InstructorAvailablePeriod> builder)
        {
            builder.HasOne(iap => iap.Instructor)
                .WithMany(i => i.InstructorAvailablePeriods)
                .HasForeignKey(iap => iap.InstructorId);
        }
    }
}
