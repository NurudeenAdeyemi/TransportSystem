using System;
using System.Collections.Generic;
using System.Text;

namespace TransportSystem.Core.Entities
{
    public class Passenger :  BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string PasswordHash { get; set; }

        public string HashSalt { get; set; }

        public string NextOfKin { get; set; }

        public IList<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
