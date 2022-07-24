using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly OperatorServices operatorServices;
        public OperatorController(OperatorServices operatorServices)
        {
            this.operatorServices = operatorServices;

        }

        // Operator/AddFlight is used to add new flight at a route by using post method

        [HttpPost("AddFlight")]

        public ErrorResponse  Post(AddFlightRequest addFlightRequest)
        {
            var result= operatorServices.add_New_Flight_At_A_Route(addFlightRequest.Name, addFlightRequest.Eseats, addFlightRequest.Bseats, addFlightRequest.Fseats, addFlightRequest.RouteId);
            return result;
        }

        // Operator.Delete is used to delete a flight by using Delete method

        [HttpDelete("DeleteFlight")]
        public void Delete(int routeId , int planeId)
        {
            var routeplane = new RoutePlane
            {
                PlaneId=planeId,
                RouteId=routeId
            };
            operatorServices.remove_Flight_at_route(routeplane);

        }

    }
}
