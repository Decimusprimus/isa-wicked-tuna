using System.Collections.Generic;
using WickedTunaCore.Cottages;

namespace WickedTunaCore.Users
{
    public class CottageOwner : TUser
    {
        public ICollection<Cottage> Cottages { get; set; }
    }
}
