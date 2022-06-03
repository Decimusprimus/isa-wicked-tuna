using System;
using WickedTunaCore.Users;

namespace WickedTunaCore.Cottages
{
    public class CottageReservation
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NumberOfPeople { get; set; } 
        //public float Reservation { get; set; }

        public Cottage Cottage { get; set; }
        public Guid CottageId { get; set; }
        public Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
