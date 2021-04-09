using System;
using System.Collections.Generic;
using System.Text;

namespace TransportSystem.Core.Entities
{
    public class Booking : BaseEntity
    {
        public Guid TripId { get; set; }

        public Trip Trip { get; set; }

        public string BookingNumber { get; set; }

        public float Price { get; set; }

        public Guid PassengerId { get; set; }

        public Passenger Passenger { get; set; }
    }
}
