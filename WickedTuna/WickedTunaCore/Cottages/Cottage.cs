using System;
using WickedTunaCore.Common;
using WickedTunaCore.Users;

namespace WickedTunaCore.Cottages
{
    public class Cottage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string AdditionalServices { get; set; }

        public string CottageOwnerId { get; set; }
        public CottageOwner CottageOwner { get; set; }
    }
}
