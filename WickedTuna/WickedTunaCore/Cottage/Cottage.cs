using System;
using WickedTunaCore.Common;

namespace WickedTunaCore.Cottage
{
    public class Cottage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public CancellationFee CancellationFee { get; set; }

    }
}
