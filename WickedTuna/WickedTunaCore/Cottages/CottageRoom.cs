using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WickedTunaCore.Cottages
{
    public class CottageRoom
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Room { get; set; }
        public int NumberOfBeds { get; set; }
        [JsonIgnore]
        public Cottage Cottage { get; set; }
        [JsonIgnore]
        public Guid CottageId { get; set; }
    }
}
