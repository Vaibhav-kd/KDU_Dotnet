using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Routes = new HashSet<Route>();
        }

        public int AirlineCode { get; set; }
        public string AirlineName { get; set; } = null!;

        public virtual ICollection<Route> Routes { get; set; }
    }
}
