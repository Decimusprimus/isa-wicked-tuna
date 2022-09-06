using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Repositories
{
    public interface IBoatReservationRepositroy : IRepository<BoatReservation>
    {
        List<BoatReservation> GetWithoutClient();
        BoatReservation CheckReservationForClient(string id, DateTime start, DateTime end);
        List<BoatReservation> GetActiveReservationsForClient(string id);
        List<BoatReservation> GetPastReservationsForClient(string id);
        BoatReservation GetById(Guid id);
        
    }
}
