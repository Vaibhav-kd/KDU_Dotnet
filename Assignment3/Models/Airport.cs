using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Airport
    {
        public Airport()
        {
            RouteArrivalAirportCodeNavigations = new HashSet<Route>();
            RouteDeparureAirportCodeNavigations = new HashSet<Route>();
        }

        public int IataAirportCode { get; set; }
        public string AirportName { get; set; } = null!;
        public int CountryCode { get; set; }
        public int CityCode { get; set; }

        public virtual City CityCodeNavigation { get; set; } = null!;
        public virtual Country CountryCodeNavigation { get; set; } = null!;
        public virtual ICollection<Route> RouteArrivalAirportCodeNavigations { get; set; }
        public virtual ICollection<Route> RouteDeparureAirportCodeNavigations { get; set; }
    }
}
