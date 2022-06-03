﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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
        public float Price { get; set; }
        //TODO: Add rooms and number of beds

        public string CottageOwnerId { get; set; }
        [JsonIgnore]
        public CottageOwner CottageOwner { get; set; }
        public ICollection<CottageAvailablePeriod> CottageAvailablePeriods { get; set; }
        [JsonIgnore]
        public ICollection<CottageReservation> CottageReservations { get; set; }
    }
}
