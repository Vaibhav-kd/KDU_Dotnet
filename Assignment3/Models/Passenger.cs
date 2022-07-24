using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int SeatNo { get; set; }
        public int UserId { get; set; }
        public int FlightInstId { get; set; }
        public string EmailId { get; set; } = null!;
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; } = null!;
        public string Confirmed { get; set; } = null!;
        public string Cancelled { get; set; } = null!;

        public virtual FlightInstance FlightInst { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
