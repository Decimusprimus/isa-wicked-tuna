using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Cottages;

namespace WickedTunaInfrastructure
{
    public class CottageRoomConfiguration : IEntityTypeConfiguration<CottageRoom>
    {
        public void Configure(EntityTypeBuilder<CottageRoom> builder)
        {
            builder.HasOne(cr => cr.Cottage)
                .WithMany(c => c.CottageRooms)
                .HasForeignKey(cr => cr.CottageId);
        }
    }
}
