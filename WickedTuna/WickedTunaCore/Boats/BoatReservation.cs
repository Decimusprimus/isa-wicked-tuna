using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaCore.Boats
{
    public class BoatReservation
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Boat Boat { get; set; }
        public Guid BoatId { get; set; }
        public Client Client { get; set; }
        public string ClientId { get; set; }


    }
}
