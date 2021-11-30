using System;
using WickedTunaCore.Common;

namespace WickedTunaCore.Adventure
{
    public class Adventure
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public int MaxNuberOfPeople { get; set; }
        public float Price { get; set; }
        public CancellationFee CancellationFee { get; set; }

    }
}
