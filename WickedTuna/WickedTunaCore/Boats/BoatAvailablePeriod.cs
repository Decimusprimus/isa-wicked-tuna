using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WickedTunaCore.Users;

namespace WickedTunaCore.Boats
{
    public class BoatAvailablePeriod
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [JsonIgnore]
        public Boat Boat { get; set; }
        [JsonIgnore]
        public Guid BoatId { get; set; }

    }
}
