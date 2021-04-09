using System;
using System.Collections.Generic;
using System.Text;

namespace TransportSystem.Core.Entities
{
    public class Bus : BaseEntity
    {
        public string BusNumber { get; set; }

        public string Capacity { get; set; }

        public string Model { get; set; }

        public string Speed { get; set; }

        public IList<Trip> Trips { get; set; } = new List<Trip>();
    }
}
