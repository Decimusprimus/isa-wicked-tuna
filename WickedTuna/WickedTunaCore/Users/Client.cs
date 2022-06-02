
using System.Collections.Generic;
using WickedTunaCore.Cottages;

namespace WickedTunaCore.Users
{
    public class Client : TUser
    {
        public ICollection<CottageReservation> CottageReservations { get; set; }
        public Client()
        {
            
        }

    }
}
