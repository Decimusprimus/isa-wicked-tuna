using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.Cottages;

namespace WickedTunaInfrastructure.Configurations
{
    public class CottageReservationConfiguration : IEntityTypeConfiguration<CottageReservation>
    {
        public void Configure(EntityTypeBuilder<CottageReservation> builder)
        {
            builder.HasOne(cr => cr.Cottage)
                .WithMany(c => c.CottageReservations)
                .HasForeignKey(cr => cr.CottageId);
            builder.HasOne(cr => cr.Client)
                .WithMany(c => c.CottageReservations)
                .HasForeignKey(cr => cr.ClientId);
            builder.Property(c => c.ClientId).IsConcurrencyToken();
        }
    }
}
