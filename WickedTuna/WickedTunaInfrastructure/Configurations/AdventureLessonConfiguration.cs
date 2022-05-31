using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WickedTunaCore.AdventuresLessons;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaInfrastructure.Configurations
{
    public class AdventureLessonConfiguration : IEntityTypeConfiguration<AdventureLesson>
    {
        public void Configure(EntityTypeBuilder<AdventureLesson> builder)
        {
            builder.OwnsOne(al => al.Address, add =>
            {
                add.Property(p => p.Street).HasColumnName(nameof(Address.Street));
                add.Property(p => p.City).HasColumnName(nameof(Address.City));
                add.Property(p => p.County).HasColumnName(nameof(Address.County));
            });
            builder.HasOne<Instructor>(al => al.Instructor)
                .WithMany(i => i.AdventureLessons)
                .HasForeignKey(al => al.InstructorId);
        }
    }
}
