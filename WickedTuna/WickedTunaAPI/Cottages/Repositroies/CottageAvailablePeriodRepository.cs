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
            return _context.CottageAvailablePeriods.FirstOrDefault(cap => cap.Start <= start && cap.End >= end && cap.CottageId == id);
        }

        public CottageAvailablePeriod GetPeriodEndWhenCancelling(Guid id, DateTime end)
        {
            return _context.CottageAvailablePeriods.FirstOrDefault(cap => cap.CottageId == id && cap.End == end);
        }

        public CottageAvailablePeriod GetPeriodStartWhenCancelling(Guid id, DateTime start)
        {
            return _context.CottageAvailablePeriods.FirstOrDefault(cap => cap.CottageId == id && cap.Start == start);
        }

        public void Remove(CottageAvailablePeriod cottageAvailablePeriod)
        {
            _context.Remove(cottageAvailablePeriod);
        }
    }
}
