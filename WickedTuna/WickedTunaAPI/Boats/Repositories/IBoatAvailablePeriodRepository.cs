using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Repositories
{
    public interface IBoatAvailablePeriodRepository : IRepository<BoatAvailablePeriod>
    {
        BoatAvailablePeriod GetPeriodForReservation(Guid id, DateTime start, DateTime end);
    }
}
