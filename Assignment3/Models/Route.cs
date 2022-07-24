using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Route
    {
        public int RouteId { get; set; }
        public int AirlineCode { get; set; }
        public int DeparureAirportCode { get; set; }
        public int ArrivalAirportCode { get; set; }

        public virtual Airline AirlineCodeNavigation { get; set; } = null!;
        public virtual Airport ArrivalAirportCodeNavigation { get; set; } = null!;
        public virtual Airport DeparureAirportCodeNavigation { get; set; } = null!;
    }
}
