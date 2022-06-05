using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WickedTunaCore.Boats
{
    public class BoatAdditionalOptions
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public Boat Boat { get; set; }
        public Guid BoatId { get; set; }

    }
}
