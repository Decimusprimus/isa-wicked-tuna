using Microsoft.EntityFrameworkCore;
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

        public List<BoatReservation> GetWithoutClient()
        {
            return _context.BoatReservations.Include(br => br.BoatReservationOptions).Where(br => br.ClientId == null && br.Start > DateTime.Now).ToList();
        }
    }
}
