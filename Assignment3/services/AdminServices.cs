using Assignment3.Models;

namespace Assignment3.services
{
    public class AdminServices
    {
        private readonly Flight_Database_SystemContext dbContext;
        public AdminServices(Flight_Database_SystemContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public  ErrorResponse  ChangeFlightDetails(int RouteId, int PlaneId)
        {
            //Admin can change the route id for a particular plane ( As a plane can be assigned to any route)
            //Change routeID for this planeID

            ErrorResponse response = new ErrorResponse();
            if (RouteId== null || PlaneId==null)
                response.error.Add($"RoutePlane not found");
            

            var ExistingAirplaneWithPlaneID = dbContext.RoutePlanes.Where(x => x.PlaneId == PlaneId).SingleOrDefault();

            
            if (ExistingAirplaneWithPlaneID == null)
                response.error.Add($"Plane with ID '{PlaneId}' was not found!");

            ExistingAirplaneWithPlaneID.RouteId = RouteId;
            return response;
        }

        public void AddAirline(int airlineCode, string airlineName)
        {
            //Add an airline ,given the required details 
            var newAirline = new Airline
            {
                AirlineCode= airlineCode,
                AirlineName=airlineName
            };
            dbContext.Airlines.Add(newAirline);

        }

        public ErrorResponse RemoveAirline(int airlineCode)
        {
            //Using airline code remove airline

            var airline = dbContext.Airlines.Where(x => x.AirlineCode == airlineCode).SingleOrDefault();
            ErrorResponse errorResponse = new ErrorResponse();

            if (airline == null)
                errorResponse.error.Add("Airline not found!");

            dbContext.Airlines.Remove(airline);
            return errorResponse;
        }



    }
}
