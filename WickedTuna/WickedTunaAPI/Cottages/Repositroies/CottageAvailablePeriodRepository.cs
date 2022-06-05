using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public class CottageAvailablePeriodRepository : Repository<CottageAvailablePeriod>, ICottageAvailablePeriodRepositroy
    {
        public CottageAvailablePeriodRepository(WickedTunaDbContext context) : base(context)
        {
        }

        public CottageAvailablePeriod GetForReservation(Guid id, DateTime start, DateTime end)
        {
            return _context.CottageAvailablePeriods.FirstOrDefault(cap => cap.Start < start && cap.End > end && cap.CottageId == id);
        }

        public void Remove(CottageAvailablePeriod cottageAvailablePeriod)
        {
            _context.Remove(cottageAvailablePeriod);
        }
    }
}
