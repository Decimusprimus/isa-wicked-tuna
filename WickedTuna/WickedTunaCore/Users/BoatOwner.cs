
using System.Collections.Generic;
using WickedTunaCore.Boats;

namespace WickedTunaCore.Users
{
    public class BoatOwner : TUser 
    {
        public ICollection<Boat> Boats { get; set; }
    }
}
