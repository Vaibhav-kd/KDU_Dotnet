using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Country
    {
        public Country()
        {
            Airports = new HashSet<Airport>();
            Cities = new HashSet<City>();
        }

        public int CountryIataCode { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Airport> Airports { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
