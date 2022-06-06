using System;
using System.Text.Json.Serialization;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaCore.Cottages
{
    public class CottageReservation
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NumberOfPeople { get; set; } 
        public string AdditionalServices { get; set; }
        public float Price { get; set; }
        public ReservationType ReservationType { get; set; } 
        public ReservationStatus ReservationStatus { get; set; }

        [JsonIgnore]
        public Cottage Cottage { get; set; }
        public Guid CottageId { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
