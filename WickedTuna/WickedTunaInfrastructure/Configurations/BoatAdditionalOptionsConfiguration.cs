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
    public class BoatAdditionalOptionsConfiguration : IEntityTypeConfiguration<BoatAdditionalOptions>
    {
        public void Configure(EntityTypeBuilder<BoatAdditionalOptions> builder)
        {
            builder.HasOne(bap => bap.Boat)
            .WithMany(b => b.BoatAdditionalOptions)
            .HasForeignKey(bap => bap.BoatId);
        }
    }
}
