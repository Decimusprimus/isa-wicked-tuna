using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Boats.Repositories
{
    public class BoatReservationRepository : Repository<BoatReservation>, IBoatReservationRepositroy
    {
        public BoatReservationRepository(WickedTunaDbContext context) : base(context)
        {
        }
    }
}
