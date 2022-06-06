using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public class CottageReservationRepositroy : Repository<CottageReservation>, ICottageReservationRepositroy
    {
        public CottageReservationRepositroy(WickedTunaDbContext context) : base(context)
        {
        }

        public List<CottageReservation> GetWithoutClient()
        {
            return _context.CottageReservations.Where(cr => cr.ClientId == null && cr.Start > DateTime.Now).ToList();
        }
    }
}
