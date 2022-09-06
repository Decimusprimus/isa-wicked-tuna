using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;
using WickedTunaCore.Common;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Boats.Repositories
{
    public class BoatReservationRepository : Repository<BoatReservation>, IBoatReservationRepositroy
    {
        public BoatReservationRepository(WickedTunaDbContext context) : base(context)
        {
        }

        public BoatReservation CheckReservationForClient(string id, DateTime start, DateTime end)
        {
            return _context.BoatReservations.FirstOrDefault(br => br.ClientId == id && br.Start == start && br.End == end);
        }

        public List<BoatReservation> GetActiveReservationsForClient(string id)
        {
            return _context.BoatReservations.Where(br => br.ClientId == id && (br.Start > DateTime.Now && br.ReservationStatus == ReservationStatus.Acite)).ToList();
        }

        public List<BoatReservation> GetPastReservationsForClient(string id)
        {
            return _context.BoatReservations.Where(br => br.ClientId == id && (br.Start < DateTime.Now || br.ReservationStatus == ReservationStatus.Cancelled)).ToList();
        }

        public List<BoatReservation> GetWithoutClient()
        {
            return _context.BoatReservations.Include(br => br.BoatReservationOptions).Where(br => br.ClientId == null && br.Start > DateTime.Now).ToList();
        }

        public BoatReservation GetById(Guid id)
        {
            return _context.BoatReservations.Include(br => br.BoatReservationOptions).FirstOrDefault(br => br.Id == id);
        }
    }
}
