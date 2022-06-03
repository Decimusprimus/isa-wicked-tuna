using System;
using System.Text.Json.Serialization;

namespace WickedTunaCore.Cottages
{
    public class CottageAvailablePeriod
    {
        public Guid Id {get; set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [JsonIgnore]
        public Cottage Cottage { get; set; }
        public Guid CottageId { get; set; }
    }
}
