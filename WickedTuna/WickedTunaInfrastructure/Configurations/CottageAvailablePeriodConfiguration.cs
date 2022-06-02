using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.Cottages;

namespace WickedTunaInfrastructure.Configurations
{
    public class CottageAvailablePeriodConfiguration : IEntityTypeConfiguration<CottageAvailablePeriod>
    {
        public void Configure(EntityTypeBuilder<CottageAvailablePeriod> builder)
        {
            builder.HasOne(cap => cap.Cottage)
                .WithMany(c => c.CottageAvailablePeriods)
                .HasForeignKey(cap => cap.CottageId);
        }
    }
}
