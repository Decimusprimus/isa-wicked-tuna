using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaCore.Boats
{
    public class BoatReservation
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NumberOfPeople { get; set; }
        public float Price { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        [JsonIgnore]
        public Boat Boat { get; set; }
        public Guid BoatId { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        public string ClientId { get; set; }
        public ICollection<BoatReservationOptions> BoatReservationOptions { get; set; }


    }
}
