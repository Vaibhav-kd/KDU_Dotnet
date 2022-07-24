using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices adminServices;
        public AdminController(AdminServices adminServices)
        {
            this.adminServices = adminServices;

        }

        // Admin/AddAirline is used to add a airline service 
        [HttpPost("AddAirline")]
        public void Post(AddAirlineRequest addAirlineRequest)
        {
            adminServices.AddAirline(addAirlineRequest.airlineCode, addAirlineRequest.airlineName);

        }

        //Admin/DetailsUpdate is used to change the flight details
        [HttpPut("DetailsUpdate")]
        public ErrorResponse UpdateDetails(int RouteID, int PlaneId)
        {

            var result = adminServices.ChangeFlightDetails(RouteID, PlaneId);
            return result;

        }

        //Admin/DeleteAirline is used to delete airline 
        [HttpDelete("DeleteAirline")]
        public ErrorResponse Delete(int airlineCode)
        {
            var result = adminServices.RemoveAirline(airlineCode);
            return result;
        }



    }
}
