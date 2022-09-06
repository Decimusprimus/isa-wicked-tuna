using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Boats.Repositories
{
    public class BoatAvailablePeriodRepositroy : Repository<BoatAvailablePeriod>, IBoatAvailablePeriodRepository
    {
        public BoatAvailablePeriodRepositroy(WickedTunaDbContext context) : base(context)
        {
        }

        public BoatAvailablePeriod GetPeriodEndWhenCancelling(Guid id, DateTime end)
        {
            return _context.BoatAvailablePeriods.FirstOrDefault(bap => bap.BoatId == id && bap.End == end);
        }

        public BoatAvailablePeriod GetPeriodForReservation(Guid id, DateTime start, DateTime end)
        {
            return _context.BoatAvailablePeriods.FirstOrDefault(bap => bap.BoatId == id && bap.Start < start && bap.End > end);
        }

        public BoatAvailablePeriod GetPeriodStartWhenCancelling(Guid id, DateTime start)
        {
            return _context.BoatAvailablePeriods.FirstOrDefault(bap => bap.BoatId == id && bap.Start == start);
        }

        public void Remove(BoatAvailablePeriod period)
        {
            _context.BoatAvailablePeriods.Remove(period);
        }
    }
}
