using Assignment3.Models;

namespace Assignment3.services
{
    public class OperatorServices
    {
        private readonly Flight_Database_SystemContext dbContext;
        public OperatorServices(Flight_Database_SystemContext dbContext)
        {
            this.dbContext = dbContext;

        }

        //Add a new flight by creating an object and aading to the list and also performed error checking
        public ErrorResponse  add_New_Flight_At_A_Route(string name, int eseats, int bseats, int fseats, int routeID)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            var planeID = dbContext.Airplanes.Count() + 1;
            var newFlight = new Airplane
            {
                AirplaneId = planeID,
                Name = name,
                ESeats = eseats,
                BSeats = bseats,
                FSeats = fseats
            };
            dbContext.Airplanes.Add(newFlight);
            dbContext.SaveChanges();

            if (dbContext.Routes.Where(x => x.RouteId == routeID).SingleOrDefault() == null)
                errorResponse.error.Add("Route doesn't exist");

            var new_routeplane = new RoutePlane
            {
                RouteId = routeID,
                PlaneId = planeID
            };
            dbContext.RoutePlanes.Add(new_routeplane);
            return errorResponse;
        }


        //Removed flight using routePlane and also handled the error. 
        public ErrorResponse remove_Flight_at_route(RoutePlane routePlane)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            if (routePlane == null)
                errorResponse.error.Add("No plane found at given route");
            var plane = dbContext.FlightInstances.Where(x => ( x.PlaneId == routePlane.PlaneId && x.RouteId==routePlane.RouteId)).SingleOrDefault();
            
            dbContext.FlightInstances.Remove(plane);
            dbContext.RoutePlanes.Remove(routePlane);
            return errorResponse;
        }

    }
}
