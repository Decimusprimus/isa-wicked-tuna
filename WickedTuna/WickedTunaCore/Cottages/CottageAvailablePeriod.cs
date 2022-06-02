using System;

namespace WickedTunaCore.Cottages
{
    public class CottageAvailablePeriod
    {
        public Guid Id {get; set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Cottage Cottage { get; set; }
        public Guid CottageId { get; set; }
    }
}
