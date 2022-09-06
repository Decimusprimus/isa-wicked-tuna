using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public interface ICottageReservationRepositroy : IRepository<CottageReservation>
    {
        List<CottageReservation> GetWithoutClient();
        List<CottageReservation> GetActiveReservationsForClient(string id);
        List<CottageReservation> GetPastReservationsForClient(string id);
        List<CottageReservation> GetSpecialOffers();
        CottageReservation CheckReservationForClient(string id, DateTime start, DateTime end);
    }
}
