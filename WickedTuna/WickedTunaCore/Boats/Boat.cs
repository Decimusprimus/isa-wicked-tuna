using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaCore.Boats
{
    public class Boat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumberOfEngines { get; set; }
        public float EnginePower { get; set; }
        public float MaximumSpeed { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public float CancellationFee { get; set; }

        [JsonIgnore]
        public BoatOwner BoatOwner { get; set; }
        public string BoatOwnerId { get; set; }
        public ICollection<BoatAvailablePeriod> BoatAvailablePeriods { get; set; }
        [JsonIgnore]
        public ICollection<BoatReservation> BoatReservations { get; set; }

    }
}
