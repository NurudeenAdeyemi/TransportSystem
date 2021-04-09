using System;
using System.Collections.Generic;
using System.Text;

namespace TransportSystem.Core.Entities
{
    public class Trip : BaseEntity
    {
        public Guid BusId { get; set; }

        public Bus Bus { get; set; }

        public string TakeOffPoint { get; set; }

        public string Destination { get; set; }

        public DateTime DepatureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public IList<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
