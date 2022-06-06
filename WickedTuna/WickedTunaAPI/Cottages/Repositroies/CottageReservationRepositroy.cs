using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Common;
using WickedTunaCore.Cottages;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public class CottageReservationRepositroy : Repository<CottageReservation>, ICottageReservationRepositroy
    {
        public CottageReservationRepositroy(WickedTunaDbContext context) : base(context)
        {
        }

        public List<CottageReservation> GetActiveReservationsForClient(string id)
        {
            return _context.CottageReservations.Where(cr => cr.ClientId == id && (cr.Start > DateTime.Now && cr.ReservationStatus == ReservationStatus.Acite)).ToList();
        }

        public List<CottageReservation> GetPastReservationsForClient(string id)
        {
            return _context.CottageReservations.Where(cr => cr.ClientId == id && (cr.Start < DateTime.Now || cr.ReservationStatus == ReservationStatus.Cancelled)).ToList();
        }


        public List<CottageReservation> GetWithoutClient()
        {
            return _context.CottageReservations.Where(cr => cr.ClientId == null && cr.Start > DateTime.Now).ToList();
        }
    }
}
