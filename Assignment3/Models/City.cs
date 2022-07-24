using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class City
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }

        public int IataCityCode { get; set; }
        public string CityName { get; set; } = null!;
        public int CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; } = null!;
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
