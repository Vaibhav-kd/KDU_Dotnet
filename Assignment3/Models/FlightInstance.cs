using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class FlightInstance
    {
        public FlightInstance()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int InstanceId { get; set; }
        public int RouteId { get; set; }
        public int PlaneId { get; set; }
        public int ESeats { get; set; }
        public int BSeats { get; set; }
        public int FSeats { get; set; }
        public int ECost { get; set; }
        public int BCost { get; set; }
        public int FCost { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public virtual Airplane Plane { get; set; } = null!;
        public virtual RoutePlane Route { get; set; } = null!;
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
