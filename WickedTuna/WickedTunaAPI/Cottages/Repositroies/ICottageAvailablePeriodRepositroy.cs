using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public interface ICottageAvailablePeriodRepositroy : IRepository<CottageAvailablePeriod>
    {
        CottageAvailablePeriod GetForReservation(Guid id, DateTime start, DateTime end);
        void Remove(CottageAvailablePeriod cottageAvailablePeriod);
        CottageAvailablePeriod GetPeriodStartWhenCancelling(Guid id, DateTime start);
        CottageAvailablePeriod GetPeriodEndWhenCancelling(Guid id, DateTime end);
    }
}
