
using System.Collections.Generic;
using WickedTunaCore.AdventuresLessons;
using WickedTunaCore.Boats;
using WickedTunaCore.Cottages;

namespace WickedTunaCore.Users
{
    public class Client : TUser
    {
        public ICollection<CottageReservation> CottageReservations { get; set; }
        public ICollection<BoatReservation> BoatReservations { get; set; }
        public ICollection<AdventureLessonReservation> AdventureLessonReservations { get; set; } 
        public Client()
        {
            
        }

    }
}
