using System;
using WickedTunaCore.Common;

namespace WickedTunaCore.Boat
{
    public class Boat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EngineNumger { get; set; }
        public float EnginePower { get; set; }
        public float MaximumSpeed { get; set; }
        public Address Address { get; set; }
        public string ImagesFile { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public CancellationFee CancellationFee { get; set; }

    }
}
